namespace Pharmix.Data.Entities.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customers")]
    public class Customer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }            //Group name.(Ex: Nithya Kulu Manaparai)
        [StringLength(100)]
        public string District { get; set; }
        [StringLength(100)]
        public string Town { get; set; }
        [StringLength(100)]
        public string LeaderName { get; set; }      //Leader name in that group. (Ex: Nithya)
        [StringLength(20)]
        public string ContactNumber { get; set; }          //Leader's ContactNumber 
        //[StringLength(100)]
        //public string ContactPerson2 { get; set; }
        //[StringLength(100)]
        //public string ContactNumber1 { get; set; }
        //[StringLength(100)]
        //public string ContactNumber2 { get; set; }
        public virtual ICollection<CustomerDocument> CustomerDocuments { get; set; } = new HashSet<CustomerDocument>();
        public virtual ICollection<Loan> Loans { get; set; } = new HashSet<Loan>();
        public DateTime DateOfBirth { get; set; }
        [StringLength(100)]
        public string GuardianName { get; set; }   //Spouse or Guardian
        public int GuardianAge { get; set; }    //Spouse or Guardian
        public bool IsMarried { get; set; }
        public string Occupation { get; set; }
        [StringLength(150)]
        public string ResidentialAddress { get; set; }
        [StringLength(100)]
        public string NameOfBusiness { get; set; }
        [StringLength(100)]
        public string LocationOfBusiness { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = new HashSet<CustomerContact>();
    }

    [Table("CustomerDocuments")]
    public class CustomerDocument
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public long DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }

    }

    [Table("CustomerContacts")]
    public class CustomerContact
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(20)]
        public string ContactNumber { get; set; }
    }
}
