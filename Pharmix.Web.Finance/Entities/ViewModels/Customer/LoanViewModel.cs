using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Data.Entities.ViewModels.Customer
{
    public class LoanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }
        public decimal TotalAmount { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime StartedDate { get; set; }
        public decimal Principal { get; set; }
        public int TotalNoOfEMI { get; set; }
        public decimal MonthlyDue { get; set; }
        public decimal MonthlyRate { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime ExpectedCompleteDate { get; set; }
        public DateTime NextDueDate { get; set; }
        public int NoOfEMIPaid { get; set; }
        public string Status { get; set; }  //Created, BeingReviewed, Approved, Rejected, PaidOut, Closed
        //public virtual ICollection<LoanEMI> LoanEMIs { get; set; } = new HashSet<LoanEMI>();
        //public virtual ICollection<LoanDocument> LoanDocuments { get; set; } = new HashSet<LoanDocument>();
        public int BankAccountId { get; set; }
        public BankAccountViewModel BankAccountViewModel { get; set; }
        public string RepaymentPeriod { get; set; }
        public string RepaymentTerms { get; set; }

    }
}
