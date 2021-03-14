using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class MentalHealthViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Past or present mental illness")]
        public bool MentalIllness { get; set; }

        [Display(Name = "Previous treatment/In-patient care")]
        public bool PreviousTreatment { get; set; }

        [Display(Name = "Family history")]
        public bool FamilyHistory { get; set; }

        [Display(Name = "Does your partner have any history")]
        public bool PartnerHasHistory { get; set; }

        [Display(Name = "Feeling down, depressed or hopeless")]
        public bool Depressed1st { get; set; }

        public bool Depressed2nd { get; set; }

        [Display(Name = "Having litle interest or pleasure in doing things")]
        public bool Interest1st { get; set; }

        public bool Interest2nd { get; set; }

        [Display(Name = "Worrying or feeling veri anxious about things")]
        public bool Anxious1st { get; set; }

        public bool Anxious2nd { get; set; }

        [Display(Name = "Is this something you feel you need or help with")]
        public bool NeedSomething1st { get; set; }

        public bool NeedSomething2nd { get; set; }

        [Display(Name = "Referal required (record on page 13)")]
        public bool RefferalRequired1st { get; set; }

        public bool RefferalRequired2nd { get; set; }

        [Display(Name = "Details")]
        public string Detail { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }
}
