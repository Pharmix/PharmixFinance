using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class PlanOfCareViewModel
    {
        public int Id { get; set; }

        public string PlannedPlaceOfBirth { get; set; }

        public string LeadProfessional { get; set; }

        public string JobTitle { get; set; }

        public string ReasonIfChanged { get; set; }

        public int PregnancyId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Registered")]
        public DateTime? CreatedDate { get; set; }
    }

    public class MainPlanOfCareViewModel
    {
        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }

        public List<PlanOfCareViewModel> PlanOfCareViewModel { get; set; }
    }
}
