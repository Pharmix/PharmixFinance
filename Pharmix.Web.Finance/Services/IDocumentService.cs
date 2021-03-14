using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services
{
    public interface IDocumentService
    {
        long CreateDocument(DocumentViewModel documentViewModel);
        List<DocumentViewModel> GetDocumentsByLoan(int loanId);
        List<DocumentViewModel> GetDocumentsByCustomer(int customerId);
        DocumentViewModel GetDocumentById(long documentId);
    }
}
