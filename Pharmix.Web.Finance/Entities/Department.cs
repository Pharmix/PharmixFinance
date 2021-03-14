using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pharmix.Data.Entities.Context;

namespace Pharmix.Web.Entities
{
    [Table("Department", Schema = "trusts")]
    public class Department : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int? TrustId { get; set; }
        [ForeignKey("TrustId")]
        public virtual Trust Trust { get; set; }
    }

    [Table("UserDepartment", Schema = "trusts")]
    public class UserDepartment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserDepartmentId { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}