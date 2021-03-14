using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.Context;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using Pharmix.Web.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = Pharmix.Data.Entities.Context.Document;

namespace Pharmix.Web.Finance.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository repository;

        public DocumentService(IRepository repository)
        {
            this.repository = repository;
        }

        public long CreateDocument(DocumentViewModel documentViewModel)
        {

            Data.Entities.Context.Document document = null;
            document = repository.GetContext().Documents.Where(e => e.Id == documentViewModel.Id).FirstOrDefault();

            if (document == null)
            {   //Directory with same name already exists

                var documentType = repository.GetContext().DocumentTypes.Where(x => x.Name.ToLower() == documentViewModel.DocumentTypeViewModel.Name.ToLower()).FirstOrDefault();
                if (documentType == null) documentType = repository.GetContext().DocumentTypes.FirstOrDefault(x => x.Name.ToLower() == "file");
                if (documentType != null)
                {

                    document = new Data.Entities.Context.Document()
                    {

                        DocumentType = documentType,
                        Name = documentViewModel.Name,
                        Title = documentViewModel.Title
                    };
                    document = repository.SaveNew(document);

                    if (document?.Id > 0)
                    {
                        if (documentViewModel.CustomerId > 0)
                        {
                            ///Customer related documents

                            CustomerDocument customerDocument = new CustomerDocument()
                            {
                                CustomerId = documentViewModel.CustomerId,
                                DocumentId = document.Id
                            };

                            try
                            {
                                customerDocument = repository.SaveNew(customerDocument);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                        else if (documentViewModel.LoanId > 0)
                        {
                            ///Loan related documents
                            LoanDocument loanDocument = new LoanDocument()
                            {
                                DocumentId = document.Id,
                                LoanId = documentViewModel.LoanId
                            };
                            try
                            {
                                loanDocument = repository.SaveNew(loanDocument);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                    }



                }
            }
            return document != null ? document.Id : 0;
        }

        public List<DocumentViewModel> GetDocumentsByLoan(int loanId)
        {
            List<DocumentViewModel> documentViewModelList=new List<DocumentViewModel>();
            if (loanId > 0)
            {
                documentViewModelList = repository.GetContext().LoanDocuments
                    .Include("Document").Include("Document.DocumentType")
                    .Where(x => x.LoanId == loanId).Select(m => new DocumentViewModel()
                    {
                        LoanId = m.LoanId,
                        Id = m.DocumentId,
                        Title = m.Document.Title,
                        DocumentTypeId = m.Document.DocumentTypeId,
                        DocumentTypeViewModel = new DocumentTypeViewModel() {  Id = m.Document.DocumentTypeId, Name = m.Document.DocumentType.Name }
                    }).ToList();

            }
            return documentViewModelList;
        }
        public List<DocumentViewModel> GetDocumentsByCustomer(int customerId)
        {
            List<DocumentViewModel> documentViewModelList = new List<DocumentViewModel>();
            if (customerId > 0)
            {
                documentViewModelList = repository.GetContext().CustomerDocuments
                     .Include("Document").Include("Document.DocumentType")
                    .Where(x => x.CustomerId == customerId).Select(m=>  new DocumentViewModel() {
                        CustomerId = m.CustomerId,
                        Id= m.DocumentId,
                        Title = m.Document.Title,
                        DocumentTypeId = m.Document.DocumentTypeId,
                        DocumentTypeViewModel = new DocumentTypeViewModel() { Id = m.Document.DocumentTypeId, Name = m.Document.DocumentType.Name }
                    }).ToList();
            }
            return documentViewModelList;
        }
        public DocumentViewModel GetDocumentById(long documentId)
        {
            var document = new DocumentViewModel();
            if (documentId > 0)
            {
                var d = repository.GetContext().Documents
                     .Include("DocumentType")
                    .FirstOrDefault(x => x.Id == documentId);

                document = Mapper.Map<Document, DocumentViewModel>(d);
                document.DocumentTypeViewModel = new DocumentTypeViewModel() {
                    Id = d.Id,
                    Name = d.DocumentType.Name,
                };
            }
            return document;
        }
    }
}
