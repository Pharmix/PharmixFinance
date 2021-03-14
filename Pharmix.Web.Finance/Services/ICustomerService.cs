using System;
using System.Collections.Generic;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Entities;
using Pharmix.Web.Models;

namespace Pharmix.Web.Services
{
    public interface ICustomerService  
    {
        //Patient MapViewModelToCustomer(CustomerViewModel model, string user, bool performSave);
        //Patient GetCustomerById(int customerId);
        int CreateCustomer(Patient customer, string user);
        bool ValidateSuperAdminPassword(string password);
        GridViewModel GetSearchResult(SearchRequest request);
        CustomerViewModel CreateViewModel(int id);
        Customer GetCustomerById(int id);
        bool ArchiveCustomer(int id, string user);
        IEnumerable<Customer> GetAllCustomers();
        int MapViewModelToCustomer(CustomerViewModel model, string user, bool performSave);
        List<CustomerContactViewModel> GetCustomerContactsByCustomer(int customerId);
    }
}
