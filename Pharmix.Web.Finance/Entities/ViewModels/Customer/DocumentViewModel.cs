using Pharmix.Data.Entities.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Entities.ViewModels.Customer
{
    public class DocumentViewModel
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public int LoanId { get; set; }
        public int DocumentTypeId { get; set; }
        //public string DocumentTypeName { get; set; }
        public string Name { get; set; }    //Original file name
        public string Title { get; set; }    //Original file name
        public LoanViewModel LoanViewModel { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }
        public DocumentTypeViewModel DocumentTypeViewModel { get; set; }
    }

    public class DocumentTypeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
