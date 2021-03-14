using System;
using System.Collections.Generic;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Entities;
using Pharmix.Web.Entities.Context;
using Pharmix.Web.Entities.ViewModels;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using Pharmix.Web.Models;

namespace Pharmix.Web.Services
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccount> GetAllBanks();
        BankAccount GetBankAccountById(int id);
        bool ArchiveBankAccount(int id, string user);
        int SaveBankAccount(BankAccount bankAccount, string user);

        BankAccountViewModel CreateViewModel(int id);
        int MapViewModelToBAnkAccount(BankAccountViewModel model, string user, bool performSave);
        List<BankAccountViewModel> GetBankAccountsByCustomer(int customerId);
        
    }
}
