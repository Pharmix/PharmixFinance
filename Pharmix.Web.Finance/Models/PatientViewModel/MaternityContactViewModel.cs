using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class MaternityContactViewModel
    {
        public int Id { get; set; }

        public string Midwife { get; set; }

        public string MidwifePhone { get; set; }

        public string MaternityUnit { get; set; }

        public string MaternityUnitPhone { get; set; }

        public string AntenatalClinicPhone { get; set; }

        public string CommunityOfficePhone { get; set; }

        public string DeliverySuitePhone { get; set; }

        public string AmbulancePhone { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }

}
