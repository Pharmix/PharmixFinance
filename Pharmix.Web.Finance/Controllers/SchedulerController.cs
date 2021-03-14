using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Web.Entities;
using Pharmix.Web.Models.SchedulerViewModels;
using Pharmix.Web.Services;
using Pharmix.Web.Services.Repositories;

namespace Pharmix.Web.Controllers
{
    public class SchedulerController : BaseController
    {
        private readonly ITrustService trustService;
        public ISchedulerService SchServ { get; }

        public SchedulerController(UserManager<ApplicationUser> userManager, ISchedulerService schServ, ITrustService trustService) : base(userManager)
        {
            this.trustService = trustService;
            SchServ = schServ;
        }

        public IActionResult Index()
        {
            var model = new SchedulerViewModel
            {
                Title = "Patient Scheduling",
                EnableIntervalConfig = IsTrustAdmin || IsPharmixAdmin
            };

            var depts = new List<Department>();

            if (IsPharmixAdmin || IsTrustAdmin)
            {
                var trustId = IsPharmixAdmin ? HttpContext.Session.GetInt32("TrustID") ?? 1 : trustService.GetTrustIdByUser(CurrentUserName);
                depts = trustService.GetAllDepartmentsByTrustId(trustId).ToList();
            }
            else
            {
                depts = trustService.GetUserDepartments(GetCurrentUserId()).ToList();
            }

            model.Departments = new SelectList(depts, "DepartmentId", "DepartmentName");

            return View(model);
        }

        public IActionResult EntitySearch(DateTime requestDate, string searchText, DateTime? dob, int departmentId, int page = 1, int pageSize = 10)
        {
            return PartialView("_EntityGrid", SchServ.GetEntitySearchResult(requestDate, searchText, dob, departmentId, page, pageSize));
        }

        public IActionResult CalendarTimeline(DateTime requestDate, int departmentId)
        {
            var trust = trustService.GetTrustById(IsPharmixAdmin? HttpContext.Session.GetInt32("TrustID")??1: trustService.GetTrustIdByUser(CurrentUserName));
            var model = SchServ.GetCalendarTimeline(requestDate, trust, departmentId);
            
            model.EnableIntervalConfig = IsTrustAdmin || IsPharmixAdmin;

            return PartialView("_CalendarTimeline", model);
        }

        public IActionResult AppointmentDetail(int appointmentId, int entityId, string appointmentDateTime, int departmentId)
        {
            var apptTime = DateTime.ParseExact(appointmentDateTime, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
            return PartialView("_AppointmentDetail", SchServ.CreateAppointmentDetailViewModel(appointmentId, entityId, apptTime, departmentId));
        }

        public IActionResult CreateAppointment(AppointmentDetailViewModel model, string AppointmentDateTime)
        {
            model.AppointmentDateTime = DateTime.ParseExact(AppointmentDateTime, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
            return Json(SchServ.CreateAppointment(model, CurrentUserName));
        }

        public IActionResult CancelAppointment(AppointmentDetailViewModel model)
        {
            return Json(SchServ.CancelAppointment(model, CurrentUserName));
        }

        public IActionResult AppointmentHistory(int entityId)
        {
            return PartialView("_AppointmentHistory", SchServ.GetEntityDetail(entityId));
        }

        public IActionResult EntityHistorySearch(int entityId, DateTime? fromDate, DateTime? toDate, int page = 1, int pageSize = 10)
        {
            return PartialView("DisplayTemplates/GridBoxViewModel", SchServ.GetEntityHistory(entityId, fromDate, toDate, page, pageSize));
        }
        
        [HttpPost]
        public FileResult DownloadAppointments(string htmlApts, DateTime requestDate)
        {
            using(MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(htmlApts);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 30f, 20f);

                var writer = PdfWriter.GetInstance(pdfDoc, stream);
                
                var htmlWorker = new HTMLWorker(pdfDoc);

                pdfDoc.Open();
                htmlWorker.StartDocument();
                htmlWorker.Parse(sr);
                
                htmlWorker.EndDocument();
                htmlWorker.Close();
                pdfDoc.Close();

                return File(stream.ToArray(), "application/pdf", "Appointments_"+ requestDate.ToString("dd-MM-yyyy") + ".pdf");
            }
        }

        public IActionResult AppointmentIntarval()
        {
            var trust = trustService.GetTrustById(IsPharmixAdmin ? HttpContext.Session.GetInt32("TrustID") ?? 1 : trustService.GetTrustIdByUser(CurrentUserName));
            var model = SchServ.CreateAppointmentIntervalViewModel(trust);
            
            return PartialView("_AppointmentInterval", model);
        }

        public IActionResult SaveAppointmentIntarval(AppointmentIntervalViewModel model)
        {
            return Json(SchServ.SaveAppointmentInterval(model, CurrentUserName));
        }
    }
}