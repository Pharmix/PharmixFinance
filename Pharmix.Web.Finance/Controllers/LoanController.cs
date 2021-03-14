using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NReco.PdfGenerator;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Data.Enums;
using Pharmix.Web.Entities;
using Pharmix.Web.Finance.Services;
using Pharmix.Web.Models;
using Pharmix.Web.Services;

namespace Pharmix.Web.Finance.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class LoanController : Web.Controllers.BaseController
    {

        private readonly ILoanService loanService;
        private readonly ICustomerService customerService;
        private readonly ILookupService lookupService;
        private readonly IBankAccountService bankAccountService;
        private readonly IViewRenderService _viewRenderService;
        private readonly string _applicationFormDirectorypath;



        #region Constructor
        public LoanController(UserManager<ApplicationUser> userManager, ILoanService loanService, ICustomerService customerService, ILookupService lookupService
            , IBankAccountService bankAccountService, IViewRenderService viewRenderService, IHostingEnvironment env)
            : base(userManager)
        {
            this.loanService = loanService;
            this.customerService = customerService;
            this.lookupService = lookupService;
            this.bankAccountService = bankAccountService;
            _viewRenderService = viewRenderService;

            _applicationFormDirectorypath = Path.Combine(env.ContentRootPath, "Documents/ApplicationForm");
        }
        #endregion
        public IActionResult Index(int customerId)
        {
            //if (customerId > 0)
            //{
            //    TempData["CustomerId"] = customerId;    //Get only the Customer related loans
            //    var customer = customerService.GetCustomerById(customerId);
            //    ViewBag.CustomerName = customer?.Name;
            //}
            //else
            //    TempData["CustomerId"] = 0;

            ViewBag.Customers = new SelectList(customerService.GetAllCustomers(), "Id", "Name", customerId);
            ViewBag.CustomerId = customerId;
            var model = new SearchViewModel() { };
            return View(model);
        }

        public ActionResult Search(SearchRequest request, int customerId)
        {
            //var customerId = TempData.ContainsKey("CustomerId") ? Convert.ToInt32(TempData["CustomerId"]) : 0;
            //if (customerId > 0)
            //    TempData.Keep("CustomerId");
            var model = loanService.GetSearchResult(request, customerId);
            return PartialView("DisplayTemplates/GridViewModel", model);
        }



        public ActionResult Get(int id, int customerId)
        {
            var model = loanService.CreateViewModel(id);

            SelectList customerSelectList;

            if (customerId > 0)
            {
                customerSelectList = new SelectList(customerService.GetAllCustomers(), "Id", "Name", customerId);
                model.CustomerId = customerId;
            }
            else
            {
                customerSelectList = new SelectList(customerService.GetAllCustomers(), "Id", "Name", model.CustomerId);
            }

            ViewBag.Customers = customerSelectList;
            ViewBag.Status = new SelectList(lookupService.GetAllLoanStatus(), "Key", "Value", model.Status);
            ViewBag.BankAccounts = new SelectList(bankAccountService.GetAllBanks(), "Id", "AccountNumber", model.BankAccountId);
            return PartialView("_LoanForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LoanViewModel model)
        {

            if (ModelState.IsValid)
            {
                var response = loanService.MapViewModelToLoan(model, CurrentUserName, true);

                return Json(response > 0);
            }
            else
                return Json(false);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(loanService.ArchiveLoan(id, CurrentUserName));
        }

        public PartialViewResult GetUploadDocumentView(int loanId)
        {
            LoanViewModel loanViewModel = new LoanViewModel() { Id = loanId };

            return PartialView("_UploadDocuments", loanViewModel);
        }

        public ActionResult TestUploadDocument(int loanId)
        {
            LoanViewModel loanViewModel = new LoanViewModel() { Id = loanId };

            return View("_UploadDocuments", loanViewModel);
        }

        public ViewResult CreateLoanApplication(int Id)
        {
            LoanViewModel loanViewModel = new LoanViewModel();
            if (Id > 0)
            {
                loanViewModel = loanService.CreateViewModel(Id);

                var customerViewModel = customerService.CreateViewModel(loanViewModel.CustomerId);
                loanViewModel.CustomerViewModel = customerViewModel;

                var bankAccountViewModel = bankAccountService.CreateViewModel(loanViewModel.BankAccountId);
                loanViewModel.BankAccountViewModel = bankAccountViewModel;
            }
            //var bytes = PdfConverter("AppForm.html").Result;
            return View("LoanApplication", loanViewModel);
        }

        private async Task<byte[]> PdfConverter(string fileName)
        {
            //html = "<div class='col-sm-12'><img src='" + Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") +
            //        "/Images/Barcode-ObservationConsultation.jpg' height='70' width='126' style='float:right'/><div style='clear:both'></div></div>" + html;

            string viewHtml = string.Empty;

            viewHtml = await _viewRenderService.RenderViewToStringAsync(this.ControllerContext, "LoanApplication", new LoanViewModel(), TempData);


            string applicationFormFilePath = _applicationFormDirectorypath + "/" + fileName;
            string applicationFormOutputFilePath = _applicationFormDirectorypath + "/Generated_" + fileName;

            if (!Directory.Exists(_applicationFormDirectorypath))
                Directory.CreateDirectory(_applicationFormDirectorypath);

            System.IO.File.WriteAllText(applicationFormFilePath, viewHtml, Encoding.UTF8);



            //var headerText = "<br/><b>" + patient.SName + ", " + patient.FName + "</b>&nbsp;&nbsp;&nbsp;&nbsp;PAS No: " + patient.PasNo + "&nbsp;&nbsp;&nbsp;&nbsp;DOB: " + (string.IsNullOrEmpty(patient.DOB) ? "N/A" : dob.ToString("dd/MM/yyyy")) + (string.IsNullOrEmpty(patient.NHS_No) ? "" : " NHS No :" + patient.NHS_No);

            byte[] convertedPdfBytes;

            try
            {
                var pdfConverter = new HtmlToPdfConverter
                {
                    //PageHeaderHtml = "",
                    Orientation = PageOrientation.Portrait,
                    LowQuality = false,
                    Margins = new PageMargins { Bottom = 20, Left = 10, Right = 10, Top = 20 },
                    //PageFooterHtml =
                    //    "<center><small>Generated by Our Clinic Report Generator on " + DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss") + "<span class='page'></span>" +
                    //"</center></small>"
                };

                //pdfConverter.PageHeaderHtml = headerText + "<div style='vertical-align: middle; font-size: 12px;font-weight:bold; color: #fff;background-color:#007fff;margin: 20px 0px 10px 0px; padding: 5px 5px;float:right'>Page <b class='page'></b> of <b class='topage'></b></div><div style='clear:both;'></div>";


                convertedPdfBytes = pdfConverter.GeneratePdfFromFile(applicationFormFilePath, null);//Creates pdf very quickly from html file than content itself

                System.IO.File.WriteAllBytes(_applicationFormDirectorypath + "/ " + Path.GetFileNameWithoutExtension(fileName) + ".pdf", convertedPdfBytes);

                //if (!ignoreDownload)
                //{
                //    Response.Clear();
                //    var ms = new MemoryStream(convertedPdfBytes);
                //    Response.ContentType = "application/pdf";
                //    Response.AddHeader("Refresh", "3;URL=/Clinic/ClinicPatientManager.aspx");
                //    Response.AddHeader("content-disposition", "attachment;filename=PatientClinicalInfo_" + Path.GetFileNameWithoutExtension(fileName) + ".pdf");
                //    Response.Buffer = true;
                //    ms.WriteTo(Response.OutputStream);
                //    Response.End();
                //}
            }
            catch (Exception ex)
            {
                convertedPdfBytes = null;
            }
            return convertedPdfBytes;
        }
    }
}