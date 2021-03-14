using Pharmix.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class YourDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Marriage Status")]
        public MarriageStatusEnum? MarriageStatus { get; set; }

        [Display(Name = "Family name at birth")]
        public string FamilyName { get; set; }

        [Display(Name = "Country of birth")]
        public string CountryOfBirth { get; set; }

        [Display(Name = "If not UK, Year of entry")]
        public int? YearOfEntry { get; set; }

        [Display(Name = "Faith / Religion")]
        public string Faith { get; set; }

        [Display(Name = "Citizenship status")]
        public string CitizenshipStatus { get; set; }

        [Display(Name = "Disability")]
        public bool Disability { get; set; }

        [Display(Name = "Details") ]
        public string Details { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }
}
