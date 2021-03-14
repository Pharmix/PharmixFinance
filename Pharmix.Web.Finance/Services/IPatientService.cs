using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Models;
using Pharmix.Web.Models.PatientViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Pharmix.Web.Entities;

namespace Pharmix.Web.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        bool HasDuplicateRecord(int patId, string NHS, string PAS);
        GridViewModel GetSearchResult(SearchRequest request);
        PatientViewModel GetCreateViewModel();
        Task<bool> CreateUser(PatientViewModel model);
        PregnancyViewModel GetDetail(string UserId, int PatientId, bool isPharmixAdmin);
        bool SaveDetail(PregnancyViewModel model, string UserId);

        CommunicationNeedViewModel GetCommunicationNeed(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveCommunicationNeed(CommunicationNeedViewModel model, string UserId);

        MainPlanOfCareViewModel GetPlanOfCare(int PatientId, string UserId, bool isPharmixAdmin);
        bool SavePlanOfCare(MainPlanOfCareViewModel model, string UserId);

        MaternityContactViewModel GetMaternityContact(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveMaternityContact(MaternityContactViewModel model, string UserId);

        PrimaryCareContactViewModel GetPrimaryCareContact(int PatientId, string UserId, bool isPharmixAdmin);
        bool SavePrimaryCareContact(PrimaryCareContactViewModel model, string UserId);

        NextOfKinViewModel GetNextOfKin(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveNextOfKin(NextOfKinViewModel model, string UserId);

        EmergencyContactViewModel GetEmergencyContact(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveEmergencyContact(EmergencyContactViewModel model, string UserId);

        YourDetailViewModel GetYourDetail(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveYourDetail(YourDetailViewModel model, string UserId);

        PartnerDetailViewModel GetPartnerDetail(int PatientId, string UserId, bool isPharmixAdmin);
        bool SavePartnerDetail(PartnerDetailViewModel model, string UserId);

        MedicalHistoryViewModel GetMedicalHistory(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveMedicalHistory(MedicalHistoryViewModel model, string UserId);

        MentalHealthViewModel GetMentalHealth(int PatientId, string UserId, bool isPharmixAdmin);
        bool SaveMentalHealth(MentalHealthViewModel model, string UserId);

        bool BulkUploadPatient(DataTable dt, string user);
    }
}
