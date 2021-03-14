using Pharmix.Data.Entities.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Data.Entities.ViewModels.Customer
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }
    }
}
