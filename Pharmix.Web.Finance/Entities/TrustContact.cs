namespace Pharmix.Data.Entities.Context
{
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("TrustContacts")]
    public class TrustContact
    {
        public long Id { get; set; }
        public int  TrustId { get; set; }
        [ForeignKey("TrustId")]
        public virtual Trust Trust { get; set; }
        public long ContactId { get; set; }
        [ForeignKey("ContactId ")]
        public virtual Contact Contact { get; set; }
    }
}
