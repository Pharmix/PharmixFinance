using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Enums;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using Pharmix.Web.Finance.Services;
using Pharmix.Web.Services;

namespace Pharmix.Web.Finance.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class DocumentController : Controller
    {
        public readonly IDocumentService documentService;
        private string rootPath;
        private ILoanService loanService;
        private ICustomerService customerService;
        private readonly string _customerDocumentpath;
        private readonly string _loanDocumentpath;
        public DocumentController(IDocumentService documentService, IHostingEnvironment env, ILoanService loanService, ICustomerService customerService)
        {
            this.documentService = documentService;
            this.rootPath = env.ContentRootPath;
            this.loanService = loanService;
            this.customerService = customerService;


            _customerDocumentpath = Path.Combine(rootPath, "Documents/Customer");
            _loanDocumentpath = Path.Combine(rootPath, "Documents/Loan");
        }
        public IActionResult Upload(DocumentViewModel documentViewModel)
        {
            string filePath = string.Empty;
            if (TempData.ContainsKey("CustomerId"))
            {
                TempData.Keep("CustomerId");
            }
            if (documentViewModel.LoanId > 0 || documentViewModel.CustomerId > 0)
            {
                if (documentViewModel.LoanId > 0)
                {
                    filePath = _loanDocumentpath;
                    var loan = loanService.GetLoanById(documentViewModel.LoanId);
                    if (loan != null && loan.Id > 0)
                    {
                        documentViewModel.LoanViewModel = new Data.Entities.ViewModels.Customer.LoanViewModel()
                        {
                            Id = loan.Id,
                            Name = loan.Name,
                        };
                    }
                }
                else if (documentViewModel.CustomerId > 0)
                {
                    filePath = _customerDocumentpath;
                    var customer = customerService.GetCustomerById(documentViewModel.CustomerId);
                    if (customer != null && customer.Id > 0)
                    {
                        documentViewModel.CustomerViewModel = new Data.Entities.ViewModels.Customer.CustomerViewModel()
                        {
                            Id = customer.Id,
                            Name = customer.Name
                        };
                    }
                }
            }

            ViewBag.DirectoryPath = filePath;    //Added for image preview.

            ViewBag.UploadedDocuments = documentViewModel.LoanId > 0
                ? documentService.GetDocumentsByLoan(documentViewModel.LoanId)
                : (documentViewModel.CustomerId > 0 ? documentService.GetDocumentsByCustomer(documentViewModel.CustomerId) : new List<DocumentViewModel>());
            return View("UploadDocuments", documentViewModel);
        }

        [HttpPost]
        public IActionResult Upload()
        {
            if (TempData.ContainsKey("CustomerId"))
            {
                TempData.Keep("CustomerId");
            }
            var form = this.Request.Form;
            var file = form.Files[0];
            long documentId = Convert.ToInt64(form["Id"].ToString());
            var loanId = Convert.ToInt32(form["LoanId"].ToString());
            var customerId = Convert.ToInt32(form["CustomerId"].ToString());
            var title = form["Title"].ToString();

            if (file != null)
            {
                string oldFileName = file.FileName.Split('.')[0];
                string fileType = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                //var allowedDocumentTypes = Enum.GetValues(typeof(Pharmix.Data.Enums.DocumentType)).Cast<Pharmix.Data.Enums.DocumentType>().ToList();
                var allowedDocumentTypes = Enum.GetNames(typeof(DocumentTypeEnum)).Select(x => x.ToLower()).ToList();
                if (allowedDocumentTypes.Contains(fileType.ToLower()))
                {

                    DocumentViewModel documentViewModel = new DocumentViewModel()
                    {
                        DocumentTypeViewModel = new DocumentTypeViewModel() { Name = fileType.ToUpper() },
                        //DocumentTypeName = ,
                        LoanId = loanId,
                        CustomerId = customerId,
                        Name = oldFileName,
                        Title = title
                    };

                    documentId = documentService.CreateDocument(documentViewModel);
                    if (documentId > 0 && (documentViewModel.LoanId > 0 || documentViewModel.CustomerId > 0))
                    {

                        string documentPath = documentViewModel.LoanId > 0 ? "Documents/Loan" : (documentViewModel.CustomerId > 0 ? "Documents/Customer" : string.Empty);

                        string directoryPath = documentViewModel.LoanId > 0 ? _loanDocumentpath : _customerDocumentpath;

                        //string documentPath = documentViewModel.LoanId > 0 ? "Documents/Loan" : (documentViewModel.CustomerId > 0 ? "Documents/Customer" : string.Empty);
                        //string directoryPath = Path.Combine(rootPath, documentPath);


                        if (!System.IO.Directory.Exists(directoryPath))
                            System.IO.Directory.CreateDirectory(directoryPath);

                        string newFileName = string.Format("{0}.{1}", documentId, fileType);

                        string filePath = string.Format("{0}/{1}", directoryPath, newFileName);
                        try
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }

            List<DocumentViewModel> documentViewModelList = loanId > 0 ? documentService.GetDocumentsByLoan(loanId) : (customerId > 0 ? documentService.GetDocumentsByCustomer(customerId) : new List<DocumentViewModel>());
            return PartialView("_documents", documentViewModelList);
        }

        /// <summary>
        /// List all the documents of loan or customer
        /// </summary>
        /// <param name="documentViewModel"></param>
        /// <returns></returns>
        public PartialViewResult Documents(DocumentViewModel documentViewModel)
        {
            if (TempData.ContainsKey("CustomerId"))
            {
                TempData.Keep("CustomerId");
            }
            List<DocumentViewModel> documentViewModelList = new List<DocumentViewModel>();
            return PartialView("_documents", documentViewModelList);
        }

        public IActionResult Download(DocumentViewModel documentViewModel)
        {
            var queryString = Request.Query;
            var document = documentService.GetDocumentById(documentViewModel.Id);

            //string documentPath = documentViewModel.LoanId > 0 ? "Documents\\Loan" : (documentViewModel.CustomerId > 0 ? "Documents\\Customer" : string.Empty);
            //string directoryPath = Path.Combine(rootPath, documentPath);

            string directoryPath = documentViewModel.LoanId > 0 ? _loanDocumentpath : _customerDocumentpath;

            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);

            string newFileName = string.Format("{0}.{1}", documentViewModel.Id, document.DocumentTypeViewModel.Name);

            string filePath = string.Format("{0}\\{1}", directoryPath, newFileName);

            var stream = System.IO.File.OpenRead(filePath);
            //var mimeType = "application/unknown";
            var mimeType = string.Empty; ;

            mimeType = "application/unknown";

            return File(stream, mimeType, newFileName);

        }

        public string DownloadImage(DocumentViewModel documentViewModel)
        {
            var queryString = Request.Query;
            var document = documentService.GetDocumentById(documentViewModel.Id);

            string directoryPath = documentViewModel.LoanId > 0 ? _loanDocumentpath : _customerDocumentpath;

            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);

            string newFileName = string.Format("{0}.{1}", documentViewModel.Id, document.DocumentTypeViewModel.Name);

            string filePath = string.Format("{0}\\{1}", directoryPath, newFileName);

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            return Convert.ToBase64String(data);
        }
    }
}