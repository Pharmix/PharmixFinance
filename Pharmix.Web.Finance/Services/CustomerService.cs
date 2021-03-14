using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Data.Enums;
using Pharmix.Services;
using Pharmix.Web.Entities;
using Pharmix.Web.Finance.Services.Mappers;
using Pharmix.Web.Models;
using Pharmix.Web.Services.Mappers;
using Pharmix.Web.Services.Repositories;
using X.PagedList;

namespace Pharmix.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        #region Constructor
        public CustomerService(IRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        ///// <summary>
        ///// Map Customer View model to Customer object
        ///// </summary>
        ///// <param name="model"></param>
        ///// <param name="user"></param>
        ///// <param name="performSave"></param>
        ///// <returns></returns>
        //public Patient MapViewModelToCustomer(CustomerViewModel model, string user, bool performSave)
        //{
        //    var customer = GetCustomerById(model.CustomerId);
        //    customer = customer == null ? Mapper.Map<CustomerViewModel, Patient>(model) : Mapper.Map(model, customer);

        //    if (!performSave) return customer;

        //    CreateCustomer(customer, user);

        //    return customer;
        //}

        ///// <summary>
        ///// Get Customer by ID
        ///// </summary>
        ///// <param name="customerId"></param>
        ///// <returns></returns>
        //public Patient GetCustomerById(int customerId)
        //{
        //    return _repository.GetContext().Patients.Find(customerId);
        //}

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public int CreateCustomer(Patient customer, string user)
        {
            var existingCustomer = _repository.GetContext().Patients.FirstOrDefault(m => m.EmailAddress.Equals(customer.EmailAddress, StringComparison.CurrentCultureIgnoreCase));
            if (existingCustomer != null)
            {
                return existingCustomer.Id;
            }

            customer.RegisteredDate = DateTime.Now;
            customer.SetCreateDetails(user);
            var newCustomer = _repository.SaveNew(customer);

            return newCustomer.Id;
        }

        /// <summary>
        /// Validate super admin password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateSuperAdminPassword(string password)
        {
            //string dynPassword = "Admin_" + DateTime.Now.ToString("ddMMyyyy");
            string dynPassword = "Admin@123";
            return password.Equals(dynPassword);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.GetContext().Customers.Include("Loans").Where(e => !e.IsArchived);
        }

        public GridViewModel GetSearchResult(SearchRequest request)
        {
            var model = CustomerMapper.CreateGridViewModel();

            var pageResult = QueryListHelper.SortResults(GetAllCustomers(), request);
            var serviceRows = pageResult
                .Where(p => string.IsNullOrEmpty(request.SearchText) || p.Name.StartsWith(request.SearchText, StringComparison.CurrentCultureIgnoreCase))
                .Select(CustomerMapper.BindGridData);
            try
            {
                model.Rows = serviceRows.ToPagedList(request.Page ?? 1, request.PageSize);
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public Customer GetCustomerById(int id)
        {
            return _repository.GetById<Customer>(id);
        }

        public CustomerViewModel CreateViewModel(int id)
        {
            var customer = GetCustomerById(id);
            var model = customer == null ? new CustomerViewModel() { DateOfBirth = new DateTime(2000, 01, 01) } : Mapper.Map<Customer, CustomerViewModel>(customer);
            model.CustomerContactViewModelList = GetCustomerContactsByCustomer(id);
            model.MaritialStatus = model.IsMarried ? MarriageStatusEnum.Married.ToString() : MarriageStatusEnum.Single.ToString();
            return model;
        }

        public int MapViewModelToCustomer(CustomerViewModel model, string user, bool performSave)
        {
            var customer = GetCustomerById(model.Id);

            customer = customer == null ? Mapper.Map<CustomerViewModel, Customer>(model) :
                Mapper.Map(model, customer);

            customer.IsMarried = model.MaritialStatus.Equals(MarriageStatusEnum.Married.ToString(), StringComparison.InvariantCultureIgnoreCase);

            if (!performSave) return customer.Id;

            if (customer.Id > 0)
            {
                customer.SetUpdateDetails(user);
                _repository.SaveExisting(customer);
            }
            else
            {
                customer.SetCreateDetails(user);
                _repository.SaveNew(customer);
                if (customer != null && customer.Id > 0 && model.CustomerContactViewModelList != null && model.CustomerContactViewModelList.Count() > 0)
                {
                    CustomerContact customerContact;
                    foreach (var customerContactViewModel in model.CustomerContactViewModelList)
                    {
                        customerContact = new CustomerContact();
                        customerContact.Name = customerContactViewModel.Name;
                        customerContact.ContactNumber = customerContactViewModel.ContactNumber;
                        customerContact.CustomerId = customer.Id;
                        _repository.SaveNew(customerContact);
                    }
                }
            }

            return customer.Id;
        }

        public bool ArchiveCustomer(int id, string user)
        {
            var customer = _repository.GetById<Customer>(id);

            customer.SetArchiveDetails(user);
            _repository.SaveExisting(customer);

            return true;
        }

        public List<CustomerContactViewModel> GetCustomerContactsByCustomer(int customerId)
        {
            if (customerId <= 0)
                return new List<CustomerContactViewModel>();
            else
            {
                var customerContacts = _repository.GetContext().CustomerContacts.Where(x => x.CustomerId == customerId);
                return Mapper.Map<List<CustomerContact>, List<CustomerContactViewModel>>(customerContacts.ToList());
            }
        }

    }
}
