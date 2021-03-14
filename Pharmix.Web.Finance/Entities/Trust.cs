using Pharmix.Web.Entities;

namespace Pharmix.Data.Entities.Context
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Trusts", Schema = "trusts")]
    public class Trust : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public byte[] LogoImage { get; set; }
        [StringLength(200)]
        public string LogoImageName { get; set; }
        [StringLength(12)]
        public string MondayOpenTiming { get; set; }
        [StringLength(12)]
        public string TuesdayOpenTiming { get; set; }
        [StringLength(12)]
        public string WednesdayOpenTiming { get; set; }
        [StringLength(12)]
        public string ThursdayOpenTiming { get; set; }
        [StringLength(12)]
        public string FridayOpenTiming { get; set; }
        [StringLength(12)]
        public string SaturdayOpenTiming { get; set; }
        [StringLength(12)]
        public string SundayOpenTiming { get; set; }
        [StringLength(12)]
        public string MondayEndTiming { get; set; }
        [StringLength(12)]
        public string TuesdayEndTiming { get; set; }
        [StringLength(12)]
        public string WednesdayEndTiming { get; set; }
        [StringLength(12)]
        public string ThursdayEndTiming { get; set; }
        [StringLength(12)]
        public string FridayEndTiming { get; set; }
        [StringLength(12)]
        public string SaturdayEndTiming { get; set; }
        [StringLength(12)]
        public string SundayEndTiming { get; set; }
        public int AppointmentIntervalMins { get; set; }
        public virtual ICollection<TrustAddress> TrustAddresses { get; set; } = new HashSet<TrustAddress>();
        public virtual ICollection<TrustContact> TrustContacts { get; set; } = new HashSet<TrustContact>();
        public virtual ICollection<Department> TrustDepartments { get; set; } = new HashSet<Department>();
    }
    [Table("UserTrust")]
    public class UserTrust {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TrustId { get; set; }
        [ForeignKey("TrustId")]
        public virtual Trust Trust { get; set; }
        public string UserId { get; set; }
    }
}
