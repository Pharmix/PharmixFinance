using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Entities;
using Pharmix.Web.Models.PatientViewModel;
using Pharmix.Web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pharmix.Web.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(UserManager<ApplicationUser> userManager, IPatientService patientService) : base(userManager)
        {
            this._patientService = patientService;
        }

        // GET: /<controller>/
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(_patientService.GetCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hasDuplicate = _patientService.HasDuplicateRecord(0, model.NHSNumber, model.PASNumber);
                if (hasDuplicate)
                {
                    model.GenderList = _patientService.GetCreateViewModel().GenderList;
                    ModelState.AddModelError("PASNumber", "Duplicate PAS number found.");

                    return View(model);
                }

                model.PatientAdmin = CurrentUserId.ToString();
                var createUser = await _patientService.CreateUser(model);
                if (createUser)
                    return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Detail(int PatientId)
        {
            var model = _patientService.GetDetail(CurrentUserId.ToString(), PatientId, IsPharmixAdmin||IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult Detail(PregnancyViewModel model)
        {
            var hasDuplicate = _patientService.HasDuplicateRecord(model.PatientId, model.NHSNumber, model.PASNumber);
            if (hasDuplicate)
            {
                model = _patientService.GetDetail(CurrentUserId.ToString(), model.PatientId,
                    IsPharmixAdmin || IsTrustAdmin);

                ModelState.AddModelError("PASNumber", "Duplicate PAS number found.");
                return View(model);
            }

            var SaveDetail = _patientService.SaveDetail(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("Detail", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult CommunicationNeed(int PatientId)
        {
            var model = _patientService.GetCommunicationNeed(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult CommunicationNeed(CommunicationNeedViewModel model)
        {
            var SaveDetail = _patientService.SaveCommunicationNeed(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("CommunicationNeed", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult PlanOfCare(int PatientId)
        {
            var model = _patientService.GetPlanOfCare(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult PlanOfCare(MainPlanOfCareViewModel model)
        {
            var SaveDetail = _patientService.SavePlanOfCare(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("PlanOfCare", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult MaternityContact(int PatientId)
        {
            var model = _patientService.GetMaternityContact(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult MaternityContact(MaternityContactViewModel model)
        {
            var SaveDetail = _patientService.SaveMaternityContact(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("MaternityContact", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult MedicalHistory(int PatientId)
        {
            var model = _patientService.GetMedicalHistory(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult MedicalHistory(MedicalHistoryViewModel model)
        {
            var SaveDetail = _patientService.SaveMedicalHistory(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("MedicalHistory", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult PrimaryCareContact(int PatientId)
        {
            var model = _patientService.GetPrimaryCareContact(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult PrimaryCareContact(PrimaryCareContactViewModel model)
        {
            var SaveDetail = _patientService.SavePrimaryCareContact(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("PrimaryCareContact", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult NextOfKin(int PatientId)
        {
            var model = _patientService.GetNextOfKin(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult NextOfKin(NextOfKinViewModel model)
        {
            var SaveDetail = _patientService.SaveNextOfKin(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("NextOfKin", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult EmergencyContact(int PatientId)
        {
            var model = _patientService.GetEmergencyContact(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult EmergencyContact(EmergencyContactViewModel model)
        {
            var SaveDetail = _patientService.SaveEmergencyContact(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("EmergencyContact", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult YourDetail(int PatientId)
        {
            var model = _patientService.GetYourDetail(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult YourDetail(YourDetailViewModel model)
        {
            var SaveDetail = _patientService.SaveYourDetail(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("YourDetail", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult PartnerDetail(int PatientId)
        {
            var model = _patientService.GetPartnerDetail(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult PartnerDetail(PartnerDetailViewModel model)
        {
            var SaveDetail = _patientService.SavePartnerDetail(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("PartnerDetail", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        public IActionResult MentalHealth(int PatientId)
        {
            var model = _patientService.GetMentalHealth(PatientId, CurrentUserId.ToString(), IsPharmixAdmin || IsTrustAdmin);
            return View(model);
        }

        [HttpPost]
        public IActionResult MentalHealth(MentalHealthViewModel model)
        {
            var SaveDetail = _patientService.SaveMentalHealth(model, CurrentUserId.ToString());
            if (SaveDetail)
                return RedirectToAction("MentalHealth", new { PatientId = model.PatientId });

            model.IsAdmin = true;
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchRequest request)
        {
            var model = _patientService.GetSearchResult(request);
            return PartialView("DisplayTemplates/GridViewModel", model);
        }

        private string[] patientTemplateCols = new[]
            {"FirstName", "Surname", "DateOfBirth", "Gender", "Email", "MobileNumber", "NHSNumber", "PASNumber"};
        [HttpPost]
        public IActionResult BulkUploadPatients(IFormFile file)
        {
            if (file == null) return Json(new { IsSuccess = false, Message = "Unable to find the file, please retry." });
            var sr = new StreamReader(file.OpenReadStream());
            
            var lineHeader = sr.ReadLine();
            if (lineHeader == null) return Json(new { IsSuccess = false, Message = "Invalid file format." });

            var headers = lineHeader.Split(',');
            var dt = new DataTable();
            foreach (var header in headers)
            {
                dt.Columns.Add(header);
            }

            if(patientTemplateCols.Any(c => !dt.Columns.Contains(c))) return Json(new { IsSuccess = false, Message = "Invalid file format." }); ;
            
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line == null) continue;
                
                var rows = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                var dr = dt.NewRow();
                for (var i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dt.Rows.Add(dr);
            }

            var response = _patientService.BulkUploadPatient(dt, CurrentUserName);

            if(!response) return Json(new { IsSuccess = false, Message = "Upload failed." }); ;

            return Json(new { IsSuccess = true, Message = "File uploaded succussfully." });
        }
    }
}
