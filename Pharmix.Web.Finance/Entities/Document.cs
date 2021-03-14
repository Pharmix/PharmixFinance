namespace Pharmix.Data.Entities.Context
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Documents")]
    public class Document
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }    //Original File name
        [StringLength(150)]
        public string Title { get; set; }   //When uploading we have option to get the title
        public int DocumentTypeId { get; set; }
        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }
        public string Size { get; set; }    //in KB or MB (1MB, 1024KB)

    }
    [Table("DocumentTypes")]
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }    //PDF, XLSX
        [StringLength(150)]
        public string Description { get; set; }
    }
}
