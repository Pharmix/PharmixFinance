using Pharmix.Web.Entities;

namespace Pharmix.Data.Entities.Context
{
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("TrustAddresses")]
    public class TrustAddress
    {
        public long Id { get; set; }
        public int  TrustId { get; set; }
        [ForeignKey("TrustId")]
        public virtual Trust Trust { get; set; }
        public long AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}
