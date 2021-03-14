namespace Pharmix.Data.Entities.Context
{
    using Pharmix.Web.Finance.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Loans")]
    public class Loan : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }    //Total Loan amount approved
        public DateTime StartedDate { get; set; }    //Loan Started date
        public decimal Principal { get; set; }  //Agreed Principal per month
        public int TotalNoOfEMI { get; set; }
        public decimal MonthlyDue { get; set; }
        public decimal MonthlyRate { get; set; }
        public DateTime ExpectedCompleteDate { get; set; }
        public DateTime NextDueDate { get; set; }
        public int NoOfEMIPaid { get; set; }
        public string Status { get; set; }  //Created, BeingReviewed, Approved, Rejected, PaidOut, Closed
        public string RepaymentPeriod { get; set; }
        public string RepaymentTerms { get; set; }
        public virtual ICollection<LoanEMI> LoanEMIs { get; set; } = new HashSet<LoanEMI>();
        public virtual ICollection<LoanDocument> LoanDocuments { get; set; } = new HashSet<LoanDocument>();
        public int? BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual BankAccount BankAccount { get; set; }

    }
    [Table("LoanEMIs")]
    public class LoanEMI
    {
        public long Id { get; set; }
        public int LoanId { get; set; }
        [ForeignKey("LoanId")]
        public virtual Loan Loan { get; set; }
        public decimal AmountPaid { get; set; } //Amount paid for that EMI
        public DateTime PaidDate { get; set; }

    }

    [Table("LoanDocuments")]
    public class LoanDocument
    {
        [Key]
        public int Id { get; set; }
        public int LoanId { get; set; }
        [ForeignKey("LoanId")]
        public virtual Loan Loan { get; set; }
        public long DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }


    }
}
