using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class PrimaryCareContactViewModel
    {
        public int Id { get; set; }

        public string Centre { get; set; }

        public string GPInitial { get; set; }

        public string GPSurname { get; set; }

        public string GPPostcode { get; set; }

        public string HealtVisitor { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string PhoneNumber4 { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }
}
