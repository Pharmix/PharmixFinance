using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;

using Pharmix.Web.Finance.Services.Mappers;
using Pharmix.Web.Models;
using Pharmix.Web.Services.Mappers;
using Pharmix.Web.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Pharmix.Web.Finance.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepository repository;

        public LoanService(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            //return repository.GetAll<Loan>().Where(e => !e.IsArchived);
            return repository.GetContext().Loans.Include("Customer").Where(x => !x.IsArchived);
        }
        public IEnumerable<Loan> GetLoansByCustomer(int customerId)
        {
            //return repository.GetAll<Loan>().Where(e => !e.IsArchived);
            return repository.GetContext().Loans.Include("Customer").Where(x => !x.IsArchived && x.CustomerId == customerId);
        }

        public Loan GetLoanById(int id)
        {
            return repository.GetById<Loan>(id);
        }

        public bool ArchiveLoan(int id, string user)
        {
            var loan = repository.GetById<Loan>(id);

            loan.SetArchiveDetails(user);
            repository.SaveExisting(loan);

            return true;
        }


        public int SaveLoan(Loan loan, string user)
        {
            if (loan.Id > 0)
            {
                loan.SetUpdateDetails(user);
                repository.SaveExisting(loan);
                return loan.Id;
            }

            loan.SetCreateDetails(user);
            return repository.SaveNew(loan).Id;
        }


        public GridViewModel GetSearchResult(SearchRequest request, int customerId)
        {
            var model = LoanMapper.CreateGridViewModel();
            IEnumerable<Loan> pageResult;
            if (customerId <= 0)
                pageResult = QueryListHelper.SortResults(GetAllLoans(), request);
            else
                pageResult = QueryListHelper.SortResults(GetLoansByCustomer(customerId), request);
            var serviceRows = pageResult
                .Where(p => string.IsNullOrEmpty(request.SearchText) || p.Name.StartsWith(request.SearchText, StringComparison.CurrentCultureIgnoreCase))
                .Select(LoanMapper.BindGridData);
            model.Rows = serviceRows.ToPagedList(request.Page ?? 1, request.PageSize);

            return model;
        }

        public LoanViewModel CreateViewModel(int id)
        {
            var loan = GetLoanById(id);
            var model = loan == null ? new LoanViewModel() { ExpectedCompleteDate=DateTime.Now, StartedDate=DateTime.Now} : Mapper.Map<Loan, LoanViewModel>(loan);

            return model;
        }

        public int MapViewModelToLoan(LoanViewModel model, string user, bool performSave)
        {
            var loan = GetLoanById(model.Id);

            loan = loan == null ? Mapper.Map<LoanViewModel, Loan>(model) :
                Mapper.Map(model, loan);

            if (!performSave) return loan.Id;

            if (loan.Id > 0)
            {
                loan.SetUpdateDetails(user);
                try
                {
                    repository.SaveExisting(loan);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                loan.SetCreateDetails(user);
                repository.SaveNew(loan);
            }

            return loan.Id;
        }
    }
}
