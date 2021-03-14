using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Entities;
using Pharmix.Web.Models;
using Pharmix.Web.Models.PatientViewModel;
using Pharmix.Web.Services.Mappers;
using Pharmix.Web.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Patient = Pharmix.Web.Entities.Patient;

namespace Pharmix.Web.Services
{
    public class PatientService: IPatientService
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;
        private UserManager<ApplicationUser> _userManager;

        public PatientService(UserManager<ApplicationUser> userManager, IRepository repository, IUserService userService)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _repository.GetAll<Patient>().Where(p => !p.IsArchived);
        }

        public bool HasDuplicateRecord(int patId, string NHS, string PAS)
        {
            return _repository.GetContext().Patients.Any(p => p.Id != patId &&
                p.NhsNumber.Equals(NHS, StringComparison.InvariantCultureIgnoreCase) &&
                p.PasNumber.Equals(PAS, StringComparison.InvariantCultureIgnoreCase));
        }

        public GridViewModel GetSearchResult(SearchRequest request)
        {
            var model = PatientMapper.CreateGridViewModel();
            var getAllPatient = _repository.GetContext().Patients
                    .Include(p => p.Gender)
                .Where(p => !p.IsArchived);

            var pageResult = QueryListHelper.SortResults(getAllPatient, request);
            var serviceRows = pageResult
                .Where(p => string.IsNullOrEmpty(request.SearchText) || p.GetDisplayName().ToLowerInvariant().Contains(request.SearchText.ToLowerInvariant()))
                .Select(PatientMapper.BindGridData);
            model.Rows = serviceRows.ToPagedList(request.Page ?? 1, request.PageSize);

            return model;
        }

        public PatientViewModel GetCreateViewModel()
        {
            var result = new PatientViewModel();
            
            result.GenderList = new SelectList(_repository.GetAll<Gender>(), "Id", "Name", result.GenderId);

            return result;
        }

        public async Task<bool> CreateUser(PatientViewModel patientModel)
        {
            var model = new UserViewModel
            {
                FirstName = patientModel.FirstName,
                Surname = patientModel.FirstName,
                MobileNumber = patientModel.Phone,
                Password = "Pass123!",
                Email = patientModel.Email
            };

            var user = Mapper.Map<UserViewModel, ApplicationUser>(model);
            user.UserName = model.Email;
            user.IsApproved = true;
            user.FirstName = model.FirstName;
            user.Surname = model.Surname;
            user.MobileNumber = model.MobileNumber;
            
            IdentityResult result = null;

            result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                //get patient admint Trust
                //var trustIds = _repository.GetContext().UserTrusts.Where(p => p.UserId.Equals(patientModel.PatientAdmin)).Select(p => p.TrustId).ToList();
                //model.Id = user.Id;
                //model.TrustIds = trustIds;
                //await _userService.UpdateUserDetails(model);
                var addRole = await _userManager.AddToRoleAsync(user, "Patient");

                //Add to table Patient
                var patient = new Patient
                {
                    FirstName = patientModel.FirstName,
                    Surname = patientModel.Surname,
                    EmailAddress = patientModel.Email,
                    MobileNumber = patientModel.Phone,
                    IdNumber = patientModel.IdNumber,
                    DateOfBirth = patientModel.DOB,
                    PasNumber = patientModel.PASNumber,
                    NhsNumber = patientModel.NHSNumber,
                    GenderId = patientModel.GenderId,
                    UserId = user.Id,
                    RegisteredDate = DateTime.Now
                };
                patient.SetCreateDetails(patientModel.PatientAdmin);

                var savedPatient = _repository.SaveNew(patient,patientModel.PatientAdmin);

                var pregnancy = new Pregnancy
                {
                    PatientId = savedPatient.Id
                };
                pregnancy.SetCreateDetails(patientModel.PatientAdmin);

                var savedPregnancy = _repository.SaveNew(pregnancy, patientModel.PatientAdmin);

                return true;
            }

            return false;
        }

        private bool IsAdminUser(string UserId, bool isPharmixAdmin)
        {
            var adminRole = _repository.GetContext().Roles.Where(p => p.Name == "PatientAdmin").Select(p => p.Id).FirstOrDefault();
            var applicationUser = _repository.GetContext().UserRoles.Where(p => p.UserId == UserId && p.RoleId == adminRole).ToList();

            return applicationUser.Count > 0 || isPharmixAdmin;
        }

        public PregnancyViewModel GetDetail(string UserId, int PatientId, bool isPharmixAdmin)
        {
            var result = new PregnancyViewModel();
            
            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                result.IsAdmin = true;
            }
            else
            {
                result.IsAdmin = false;
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            //var patient = _repository.GetContext().Patients.Where(p => p.Id == PatientId).FirstOrDefault();
            var pregnancy = _repository.GetContext().Pregnancy.Include(p => p.Patient).Where(p => p.PatientId == PatientId).FirstOrDefault();
            if (pregnancy != null)
            {
                result.Id = pregnancy.Id;
                result.FirstName = pregnancy.Patient.FirstName;
                result.Surname = pregnancy.Patient.Surname;
                result.DateOfBirth = pregnancy.Patient.DateOfBirth;
                //result.EDD = pregnancy.EDD;
                result.NHSNumber = pregnancy.Patient.NhsNumber;
                result.PASNumber = pregnancy.Patient.PasNumber;
                //result.MaternityUnit = pregnancy.MaternityUnit;
                result.PatientId = PatientId;
                result.GenderId = pregnancy.Patient.GenderId ?? 0;
                result.Gender = pregnancy.Patient.Gender != null ? pregnancy.Patient.Gender.Name : "N/A";
            }

            result.GenderList = new SelectList(_repository.GetAll<Gender>(), "Id", "Name", result.GenderId);

            return result;
        }

        public bool SaveDetail(PregnancyViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var patient = _repository.GetContext().Patients.Where(p => p.Id == model.PatientId).FirstOrDefault();
                patient.FirstName = model.FirstName;
                patient.Surname = model.Surname;
                patient.DateOfBirth = model.DateOfBirth;
                patient.GenderId = model.GenderId;
                patient.NhsNumber = model.NHSNumber;
                patient.PasNumber = model.PASNumber;

                patient.SetUpdateDetails(UserId);

                _repository.SaveExisting(patient);

                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.Id == model.Id).FirstOrDefault();
                //pregnancy.EDD = model.EDD;
                pregnancy.NHSNumber = model.NHSNumber;
                //pregnancy.MaternityUnit = model.MaternityUnit;

                _repository.SaveExisting(pregnancy);
                
                result = true;
            }catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        public CommunicationNeedViewModel GetCommunicationNeed(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new CommunicationNeedViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var communicationNeed = _repository.GetContext().CommunicationNeed.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (communicationNeed == null)
                result = new CommunicationNeedViewModel();
            else
                result = Mapper.Map<CommunicationNeed, CommunicationNeedViewModel>(communicationNeed);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;
            return result;
        }

        public bool SaveCommunicationNeed(CommunicationNeedViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var communicationNeed = _repository.GetContext().CommunicationNeed.Where(p => p.Id == model.Id).FirstOrDefault();
                    communicationNeed.AssistanceRequired = model.AssistanceRequired;
                    communicationNeed.AssistanceRequiredDetail = model.AssistanceRequiredDetail;
                    communicationNeed.PreferredAssistance = model.PreferredAssistance;
                    communicationNeed.SpeakEnglish = model.SpeakEnglish;
                    communicationNeed.FirstLanguage = model.FirstLanguage;
                    communicationNeed.PreferedLanguage = model.PreferedLanguage;
                    communicationNeed.InterpreterPhone = model.InterpreterPhone;
                    communicationNeed.SetUpdateDetails(UserId);

                    _repository.SaveExisting(communicationNeed);
                }
                else
                {
                    //Add new Record
                    var communicationNeed = new CommunicationNeed();
                    communicationNeed.AssistanceRequired = model.AssistanceRequired;
                    communicationNeed.AssistanceRequiredDetail = model.AssistanceRequiredDetail;
                    communicationNeed.PreferredAssistance = model.PreferredAssistance;
                    communicationNeed.SpeakEnglish = model.SpeakEnglish;
                    communicationNeed.FirstLanguage = model.FirstLanguage;
                    communicationNeed.PreferedLanguage = model.PreferedLanguage;
                    communicationNeed.InterpreterPhone = model.InterpreterPhone;
                    communicationNeed.PregnancyId = pregnancy.Id;
                    communicationNeed.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(communicationNeed);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public MainPlanOfCareViewModel GetPlanOfCare(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new MainPlanOfCareViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var planOfCare = _repository.GetContext().PlanOfCare.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId);

            List<PlanOfCareViewModel> planOfCares = Mapper.Map<List<PlanOfCareViewModel>>(planOfCare);
            
            var planCount = planOfCares.Count;
            int j = 4 - planCount;

            for(int i = 1; i <= j; i++)
            {
                var newPlan = new PlanOfCareViewModel {
                    Id = 0
                };
                planOfCares.Add(newPlan);
            }

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;
            result.PlanOfCareViewModel = planOfCares;

            return result;
        }
        
        public bool SavePlanOfCare(MainPlanOfCareViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                foreach (var plan in model.PlanOfCareViewModel)
                {
                    if(plan.Id > 0)
                    {
                        //save existing plan
                        var mapPlan = Mapper.Map<PlanOfCare>(plan);
                        mapPlan.SetUpdateDetails(UserId);

                        _repository.SaveExisting(mapPlan);
                    }
                    else if(plan.Id == 0 && (plan.CreatedDate != null || !string.IsNullOrEmpty(plan.JobTitle) || !string.IsNullOrEmpty(plan.LeadProfessional) || !string.IsNullOrEmpty(plan.ReasonIfChanged) ))
                    {
                        //save new plan
                        var newPlan = Mapper.Map<PlanOfCare>(plan);
                        newPlan.SetCreateDetails(UserId);
                        newPlan.PregnancyId = pregnancy.Id;

                        var savePlan = _repository.SaveNew(newPlan);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public MaternityContactViewModel GetMaternityContact(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new MaternityContactViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var maternityContact = _repository.GetContext().MaternityContact.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (maternityContact == null)
                result = new MaternityContactViewModel();
            else
                result = Mapper.Map<MaternityContactViewModel>(maternityContact);
            
            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveMaternityContact(MaternityContactViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var maternityContact = _repository.GetContext().MaternityContact.Where(p => p.Id == model.Id).FirstOrDefault();
                    maternityContact.Midwife = model.Midwife;
                    maternityContact.MaternityUnit= model.MaternityUnit;
                    maternityContact.MidwifePhone= model.MidwifePhone;
                    maternityContact.MaternityUnitPhone= model.MaternityUnitPhone;
                    maternityContact.AntenatalClinicPhone= model.AntenatalClinicPhone;
                    maternityContact.CommunityOfficePhone = model.CommunityOfficePhone;
                    maternityContact.DeliverySuitePhone= model.DeliverySuitePhone;
                    maternityContact.AmbulancePhone = model.AmbulancePhone;
                    maternityContact.PregnancyId = pregnancy.Id;
                    maternityContact.SetUpdateDetails(UserId);

                    _repository.SaveExisting(maternityContact);
                }
                else
                {
                    //Add new Record
                    var maternityContact = new MaternityContact();
                    maternityContact.Midwife = model.Midwife;
                    maternityContact.MaternityUnit = model.MaternityUnit;
                    maternityContact.MidwifePhone = model.MidwifePhone;
                    maternityContact.MaternityUnitPhone = model.MaternityUnitPhone;
                    maternityContact.AntenatalClinicPhone = model.AntenatalClinicPhone;
                    maternityContact.CommunityOfficePhone = model.CommunityOfficePhone;
                    maternityContact.DeliverySuitePhone = model.DeliverySuitePhone;
                    maternityContact.AmbulancePhone = model.AmbulancePhone;
                    maternityContact.PregnancyId = pregnancy.Id;
                    maternityContact.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(maternityContact);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public PrimaryCareContactViewModel GetPrimaryCareContact(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new PrimaryCareContactViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var primaryCareContact = _repository.GetContext().PrimaryCareContact.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (primaryCareContact == null)
                result = new PrimaryCareContactViewModel();
            else
                result = Mapper.Map<PrimaryCareContactViewModel>(primaryCareContact);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SavePrimaryCareContact(PrimaryCareContactViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var primaryCareContact = _repository.GetContext().PrimaryCareContact.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, primaryCareContact);
                    primaryCareContact.SetUpdateDetails(UserId);

                    _repository.SaveExisting(primaryCareContact);
                }
                else
                {
                    //Add new Record
                    var primaryCareContact = new PrimaryCareContact();
                    Mapper.Map(model, primaryCareContact);
                    primaryCareContact.PregnancyId = pregnancy.Id;
                    primaryCareContact.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(primaryCareContact);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public NextOfKinViewModel GetNextOfKin(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new NextOfKinViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var primaryCareContact = _repository.GetContext().NextOfKin.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (primaryCareContact == null)
                result = new NextOfKinViewModel();
            else
                result = Mapper.Map<NextOfKinViewModel>(primaryCareContact);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveNextOfKin(NextOfKinViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var nextOfKin = _repository.GetContext().NextOfKin.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, nextOfKin);
                    nextOfKin.SetUpdateDetails(UserId);

                    _repository.SaveExisting(nextOfKin);
                }
                else
                {
                    //Add new Record
                    var nextOfKin = new NextOfKin();
                    Mapper.Map(model, nextOfKin);
                    nextOfKin.PregnancyId = pregnancy.Id;
                    nextOfKin.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(nextOfKin);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public EmergencyContactViewModel GetEmergencyContact(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new EmergencyContactViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var emergencyContact = _repository.GetContext().EmergencyContact.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (emergencyContact == null)
                result = new EmergencyContactViewModel();
            else
                result = Mapper.Map<EmergencyContactViewModel>(emergencyContact);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveEmergencyContact(EmergencyContactViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var emergencyContact = _repository.GetContext().EmergencyContact.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, emergencyContact);
                    emergencyContact.SetUpdateDetails(UserId);

                    _repository.SaveExisting(emergencyContact);
                }
                else
                {
                    //Add new Record
                    var emergencyContact = new EmergencyContact();
                    Mapper.Map(model, emergencyContact);
                    emergencyContact.PregnancyId = pregnancy.Id;
                    emergencyContact.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(emergencyContact);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public YourDetailViewModel GetYourDetail(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new YourDetailViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var yourDetail = _repository.GetContext().YourDetail.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (yourDetail == null)
                result = new YourDetailViewModel();
            else
                result = Mapper.Map<YourDetailViewModel>(yourDetail);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveYourDetail(YourDetailViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var yourDetail = _repository.GetContext().YourDetail.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, yourDetail);
                    yourDetail.SetUpdateDetails(UserId);

                    _repository.SaveExisting(yourDetail);
                }
                else
                {
                    //Add new Record
                    var yourDetail = new YourDetail();
                    Mapper.Map(model, yourDetail);
                    yourDetail.PregnancyId = pregnancy.Id;
                    yourDetail.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(yourDetail);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public PartnerDetailViewModel GetPartnerDetail(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new PartnerDetailViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var partnerDetail = _repository.GetContext().PartnerDetail.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (partnerDetail == null)
                result = new PartnerDetailViewModel();
            else
                result = Mapper.Map<PartnerDetailViewModel>(partnerDetail);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SavePartnerDetail(PartnerDetailViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var partnerDetail = _repository.GetContext().PartnerDetail.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, partnerDetail);
                    partnerDetail.SetUpdateDetails(UserId);

                    _repository.SaveExisting(partnerDetail);
                }
                else
                {
                    //Add new Record
                    var partnerDetail = new PartnerDetail();
                    Mapper.Map(model, partnerDetail);
                    partnerDetail.PregnancyId = pregnancy.Id;
                    partnerDetail.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(partnerDetail);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public MentalHealthViewModel GetMentalHealth(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new MentalHealthViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var mentalHealth = _repository.GetContext().MentalHealth.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (mentalHealth == null)
                result = new MentalHealthViewModel();
            else
                result = Mapper.Map<MentalHealthViewModel>(mentalHealth);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveMentalHealth(MentalHealthViewModel model, string UserId)
        {
            var result = false;
            try
            {
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var mentalHealth = _repository.GetContext().MentalHealth.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, mentalHealth);
                    mentalHealth.SetUpdateDetails(UserId);

                    _repository.SaveExisting(mentalHealth);
                }
                else
                {
                    //Add new Record
                    var mentalHealth = new MentalHealth();
                    Mapper.Map(model, mentalHealth);
                    mentalHealth.PregnancyId = pregnancy.Id;
                    mentalHealth.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(mentalHealth);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        
        public MedicalHistoryViewModel GetMedicalHistory(int PatientId, string UserId, bool isPharmixAdmin)
        {
            var result = new MedicalHistoryViewModel();
            var IsAdmin = false;

            if (IsAdminUser(UserId, isPharmixAdmin))
            {
                IsAdmin = true;
            }
            else
            {
                PatientId = _repository.GetContext().Patients.Where(p => p.UserId == UserId).Select(p => p.Id).FirstOrDefault();
            }

            var medicalHistory = _repository.GetContext().MedicalHistory.Include(p => p.Pregnancy).Where(p => p.Pregnancy.PatientId == PatientId).FirstOrDefault();

            if (medicalHistory == null)
                result = new MedicalHistoryViewModel();
            else
                result = Mapper.Map<MedicalHistoryViewModel>(medicalHistory);

            result.IsAdmin = IsAdmin;
            result.PatientId = PatientId;

            return result;
        }

        public bool SaveMedicalHistory(MedicalHistoryViewModel model, string UserId)
        {
            var result = false;
            try
            {
                model.FolicAcidTabletDose = model.FolicAcidTabletDose == 5 ? 5 : (float)0.4;
                var pregnancy = _repository.GetContext().Pregnancy.Where(p => p.PatientId == model.PatientId).FirstOrDefault();
                if (model.Id > 0)
                {
                    //Update Existing
                    var medicalHisory = _repository.GetContext().MedicalHistory.Where(p => p.Id == model.Id).FirstOrDefault();
                    Mapper.Map(model, medicalHisory);
                    medicalHisory.SetUpdateDetails(UserId);

                    _repository.SaveExisting(medicalHisory);
                }
                else
                {
                    //Add new Record
                    var medicalHistory = new MedicalHistory();
                    Mapper.Map(model, medicalHistory);
                    medicalHistory.PregnancyId = pregnancy.Id;
                    medicalHistory.SetCreateDetails(UserId);

                    var saveNew = _repository.SaveNew(medicalHistory);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        private DateTime? GetDob(string input)
        {
            var valid = DateTime.TryParse(input, out var dt);
            return valid ? dt : (DateTime?) null;
        }

        private int? GetGenderId(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            switch (input.ToLower())
            {
                case "male":
                    return 1;
                case "female":
                    return 2;
                case "transgender":
                    return 3;
            }

            return null;
        }

        public bool BulkUploadPatient(DataTable dt, string user)
        {
            foreach (DataRow row in dt.Rows)
            {
                var pas = row["PASNumber"].ToString().Trim();
                if (string.IsNullOrWhiteSpace(pas)) continue;

                var nhs = row["NHSNumber"].ToString().Trim();
                var pat = _repository.GetContext().Patients.FirstOrDefault(p =>
                    p.PasNumber == pas && p.NhsNumber == nhs);
                pat = pat ?? new Patient();

                //var oldEmail = pat.EmailAddress;

                pat.FirstName = row["FirstName"].ToString();
                pat.Surname = row["Surname"].ToString();
                pat.DateOfBirth = GetDob(row["DateOfBirth"].ToString());
                pat.GenderId = GetGenderId(row["Gender"].ToString());
                pat.EmailAddress = row["Email"].ToString();
                pat.MobileNumber = row["MobileNumber"].ToString();
                pat.NhsNumber = row["NHSNumber"].ToString();
                pat.PasNumber = row["PASNumber"].ToString();

                var pregnancy = _repository.GetContext().Pregnancy.FirstOrDefault(p => p.PatientId == pat.Id);

                pregnancy = pregnancy ?? new Pregnancy();
                pregnancy.NHSNumber = pat.NhsNumber;

                if (pat.Id > 0)
                {
                    pat.SetUpdateDetails(user);
                    _repository.SaveExisting(pat);

                    pregnancy.SetUpdateDetails(user);
                    _repository.SaveExisting(pregnancy);

                    //if (!oldEmail.Equals(pat.EmailAddress, StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    var oldUser = _userManager.Users.FirstOrDefault(u =>
                    //        u.UserName.Equals(oldEmail, StringComparison.InvariantCultureIgnoreCase));
                    //    if (oldUser != null)
                    //    {
                    //        oldUser.UserName = pat.EmailAddress;

                    //        _userManager.UpdateAsync(oldUser);
                    //    }
                    //}
                    
                    continue;
                }

                pat.SetCreateDetails(user);
                _repository.SaveNew(pat);

                pregnancy.PatientId = pat.Id;
                pregnancy.SetCreateDetails(user);
                _repository.SaveNew(pregnancy);

                //var appUser = _userManager.Users.FirstOrDefault(u =>
                //    u.UserName.Equals(pat.EmailAddress, StringComparison.InvariantCultureIgnoreCase));

                //if (appUser == null)
                //{
                //    appUser = new ApplicationUser
                //    {
                //        UserName = pat.EmailAddress,
                //        IsApproved = true,
                //        FirstName = pat.FirstName,
                //        Surname = pat.Surname,
                //        MobileNumber = pat.MobileNumber
                //    };

                //    var result = _userManager.CreateAsync(appUser, "Pass123!");
                //    if (result.Exception == null)
                //    {
                //       _userManager.AddToRoleAsync(appUser, "Patient");
                //    }
                //}
            }

            return true;
        }
    }
}
