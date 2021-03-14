using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmix.Data.Entities.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string LeaderName { get; set; }
        public string ContactNumber { get; set; }
        public List<LoanViewModel> LoanViewModelList { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Age{ get { return DateOfBirth!=null? new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year - 1 : 0; } }
        public string GuardianName { get; set; }   //Spouse or Guardian
        public int GuardianAge { get; set; }
        public bool IsMarried { get; set; }
        public string Occupation { get; set; }
        public string ResidentialAddress { get; set; }
        public string NameOfBusiness { get; set; }
        public string LocationOfBusiness { get; set; }
        public List<BankAccountViewModel> BankAccountViewModelList { get; set; }
        public string MaritialStatus { get; set; }
        public List<CustomerContactViewModel> CustomerContactViewModelList { get; set; }
        //public int CustomerId { get; set; }
        //public int GenderId { get; set; }
        //public List<KeyValuePair<string,string>> Genders { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public string FirstName { get; set; }
        //public string Surname { get; set; }
        //public string NhsNumber { get; set; }
        //public string PasNumber { get; set; }

        //public string EmailAddress { get; set; }

        //public string Password { get; set; }
        //public string ConfirmPassword { get; set; }

        //public string MobileNumber { get; set; }

        //public string AlternativeTel { get; set; }

        //public string AddressLine1 { get; set; }

        //public string AddressLine2 { get; set; }

        //public string AddressLine3 { get; set; }

        //public string City { get; set; }

        //public string County { get; set; }
        //public string Postcode { get; set; }

        //public string FullAddress { get; set; }
        //public string GenderText { get; set; }

        //public List<ModuleViewModel> ModuleViewModelList { get; set; }

    }
    public class CustomerContactViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public CustomerViewModel CustomerViewModel { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public int TempId { get; set; }
    }
}
