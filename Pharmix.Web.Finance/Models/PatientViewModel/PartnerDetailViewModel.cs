using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class PartnerDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Address if different")]
        public string Address { get; set; }

        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Employed")]
        public bool Employed { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "UK citizenship status")]
        public string UKCitizenshipStatus { get; set; }

        [Display(Name = "If born in UK, year of entry")]
        public int? YearOfEntry { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }
}
