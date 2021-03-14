using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class PatientViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string IdNumber { get; set; }

        public string PatientAdmin { get; set; }
        [Required]
        public string NHSNumber { get; set; }
        [Required]
        public string PASNumber { get; set; }

        [Required]
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public SelectList GenderList { get; set; }
    }
}
