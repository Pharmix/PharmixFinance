using Pharmix.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pharmix.Web.Entities;

namespace Pharmix.Data.Entities.Context
{
    [Table("SupervisorRequest")]
    public class SupervisorRequest: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        public RequsetPriorityEnum Priority { get; set; }

        public RequestStatusEnum LatestRequestStatus { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual SupervisorRequestType RequestType { get; set; }

        public int IsolatorId { get; set; }
        [ForeignKey("IsolatorId")]
        public virtual Isolator Isolator { get; set; }

        public string RequestedBy { get; set; }

        public int? CurrentOrderId { get; set; }
        [ForeignKey("CurrentOrderId")]
        public virtual IntegrationOrder IntegrationOrder { get; set; }
    }


    [Table("SupervisorRequestTracking")]
    public class SupervisorRequestTracking : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public RequestStatusEnum RequestStatus { get; set; }

        public int RequestId { get; set; }  
        [ForeignKey("RequestId")]
        public virtual SupervisorRequest SupervisorRequest { get; set; }

        public DateTime LastModified { get; set; }
        
        public string LastModifiedUser { get; set; }
        //[ForeignKey("LastModifiedUser")]
        //public virtual ApplicationUser ApplicationUser { get; set; }

    }


    [Table("SupervisorRequestType")]
    public class SupervisorRequestType: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Type { get; set; }

    }
}
