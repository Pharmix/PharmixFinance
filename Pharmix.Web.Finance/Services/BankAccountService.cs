using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Services.Mappers;
using Pharmix.Web.Entities;
using Pharmix.Web.Entities.Context;
using Pharmix.Web.Entities.ViewModels;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using Pharmix.Web.Models;
using Pharmix.Web.Services.Mappers;
using Pharmix.Web.Services.Repositories;
using X.PagedList;

namespace Pharmix.Web.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IRepository repository;

        public BankAccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BankAccount> GetAllBanks()
        {
            return repository.GetAll<BankAccount>().Where(e => !e.IsArchived);
        }

        public BankAccount GetBankAccountById(int id)
        {
            return repository.GetById<BankAccount>(id);
        }

        public BankAccountViewModel CreateViewModel(int id)
        {
            var bankAccount = GetBankAccountById(id);
            var model = bankAccount == null ? new BankAccountViewModel() : Mapper.Map<BankAccount, BankAccountViewModel>(bankAccount);

            return model;
        }

        public bool ArchiveBankAccount(int id, string user)
        {
            var bankAccount = repository.GetById<BankAccount>(id);

            bankAccount.SetArchiveDetails(user);
            repository.SaveExisting(bankAccount);

            return true;
        }


        public int SaveBankAccount(BankAccount bankAccount, string user)
        {
            if (bankAccount.Id > 0)
            {
                bankAccount.SetUpdateDetails(user);
                repository.SaveExisting(bankAccount);
                return bankAccount.Id;
            }

            bankAccount.SetCreateDetails(user);
            return repository.SaveNew(bankAccount).Id;
        }


        public int MapViewModelToBAnkAccount(BankAccountViewModel model, string user, bool performSave)
        {
            var bankAccount = GetBankAccountById(model.Id);

            bankAccount = bankAccount == null ? Mapper.Map<BankAccountViewModel, BankAccount>(model) :
                Mapper.Map(model, bankAccount);

            if (!performSave) return bankAccount.Id;

            if (bankAccount.Id > 0)
            {
                bankAccount.SetUpdateDetails(user);
                repository.SaveExisting(bankAccount);
            }
            else
            {
                bankAccount.SetCreateDetails(user);
                repository.SaveNew(bankAccount);
            }

            return bankAccount.Id;
        }

        public List<BankAccountViewModel> GetBankAccountsByCustomer(int customerId)
        {
            var bankAccounts = repository.GetContext().BankAccounts.Include("Customer").Where(x => !x.IsArchived && x.CustomerId == customerId);
            return Mapper.Map<List<BankAccount>, List<BankAccountViewModel>>(bankAccounts.ToList());
        }
    }
}
