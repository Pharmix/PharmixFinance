using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services
{
    public interface ILoanService
    {
        IEnumerable<Loan> GetAllLoans();
        Loan GetLoanById(int id);
        int SaveLoan(Loan loan, string user);
        bool ArchiveLoan(int id, string user);

        GridViewModel GetSearchResult(SearchRequest request, int customerId);
        LoanViewModel CreateViewModel(int id);
        int MapViewModelToLoan(LoanViewModel model, string user, bool performSave);
    }
}
