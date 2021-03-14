using Pharmix.Data.Entities.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Data.Entities.Context
{
    [Table("BankAccounts")]
    public class BankAccount : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        [StringLength(100)]
        public string BankName { get; set; }
        [StringLength(20)]
        public string IFSCCode { get; set; }
        [StringLength(100)]
        public string BranchName { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}
