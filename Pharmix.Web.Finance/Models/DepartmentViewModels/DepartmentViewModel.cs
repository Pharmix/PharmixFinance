using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharmix.Web.Models.DepartmentViewModels
{
    public class DepartmentIndexViewModel
    {
        public int TrustId { get; set; }
        public SelectList TrustList { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public bool IsPharmixAdminRequest { get; set; }
    }

    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "The Department Name field is required.")]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int TrustId { get; set; }
        public SelectList TrustList { get; set; }
        public bool IsModelEditable { get; set; }
        public bool IsPharmixAdminRequest { get; set; }
    }
}
