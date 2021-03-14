using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Pharmix.Data.Entities.Context;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Data.Entities.ViewModels.Customer;
using Pharmix.Web.Entities;
using Pharmix.Web.Entities.ViewModels.IntegrationOrder;
using Pharmix.Web.Entities.Context;
using Pharmix.Web.Entities.ViewModels;
using Pharmix.Web.Models.IsolatorVIewModels;
using Pharmix.Web.Entities.ViewModels.Production;
using Pharmix.Web.Models.AccountViewModels;
using Pharmix.Web.Models.DepartmentViewModels;
using IsolatorShift = Pharmix.Web.Entities.IsolatorShift;
using Pharmix.Web.Models.ManageViewModels;
using Pharmix.Web.Models.PatientViewModel;
using Pharmix.Web.Models.SchedulerViewModels;
using Pharmix.Web.Finance.Entities.ViewModels.Customer;

namespace Pharmix.Web.Services.Mappers
{
    public class AutoMapperBootStrapper
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {

                //config.CreateMap<Patient, CustomerViewModel>().ReverseMap();
                config.CreateMap<IdentityUser, UserViewModel>().ReverseMap();
                config.CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
                config.CreateMap<IsolatorStaffAllocation, IsolatorStaffAllocationViewModel>().ReverseMap();
                config.CreateMap<IsolatorStaffAllocation, IsolatorStaffAllocation>().ForMember(m => m.IsolatorStaffAllocationId, opt => opt.Ignore());
                config.CreateMap<Isolator, IsolatorViewModel>().ReverseMap();
                config.CreateMap<IntegrationOrder, IntegrationOrderViewModel>()
                .ForMember(d => d.IntegratedSystem, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<IsolatorShift, ShiftViewModel>().ReverseMap();
                config.CreateMap<IsolatorProcedure, ProcedureViewModel>().ReverseMap();
                //config.CreateMap<IntegrationOrderViewModel, IntegrationOrder>().ReverseMap();
                config.CreateMap<SupervisorRequest, SupervisorRequestViewModel>().ReverseMap();
                config.CreateMap<Module, ModuleViewModel>().ReverseMap();
                config.CreateMap<Site, SiteViewModel>().ReverseMap();
                config.CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
                config.CreateMap<Permission, PermissionViewModel>().ReverseMap();
                config.CreateMap<Trust, TrustViewModel>().ReverseMap();
                config.CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
                config.CreateMap<Address, RegisterViewModel>().ReverseMap();
                config.CreateMap<Group, GroupViewModel>().ReverseMap();
                config.CreateMap<CommunicationNeed, CommunicationNeedViewModel>().ReverseMap();
                config.CreateMap<PlanOfCare, PlanOfCareViewModel>().ReverseMap();
                config.CreateMap<MaternityContact, MaternityContactViewModel>().ReverseMap();
                config.CreateMap<PrimaryCareContact, PrimaryCareContactViewModel>().ReverseMap();
                config.CreateMap<NextOfKin, NextOfKinViewModel>().ReverseMap();
                config.CreateMap<EmergencyContact, EmergencyContactViewModel>().ReverseMap();

                config.CreateMap<YourDetail, YourDetailViewModel>().ReverseMap();
                config.CreateMap<PartnerDetail, PartnerDetailViewModel>().ReverseMap();

                config.CreateMap<MedicalHistory, MedicalHistoryViewModel>().ReverseMap();
                config.CreateMap<MentalHealth, MentalHealthViewModel>().ReverseMap();

                config.CreateMap<Trust, AppointmentIntervalViewModel>().ReverseMap();
                config.CreateMap<Department, DepartmentViewModel>().ReverseMap();
                config.CreateMap<BankAccount, BankAccountViewModel>().ReverseMap();
                config.CreateMap<CustomerContact, CustomerContactViewModel>().ReverseMap();

                config.CreateMap<Loan, LoanViewModel>()
                .ForMember(m => m.BankAccountViewModel, opt => opt.MapFrom(x => x.BankAccount))
                .ReverseMap();

                config.CreateMap<Customer, CustomerViewModel>()
                .ForMember(m => m.LoanViewModelList, opt => opt.MapFrom(x => x.Loans))
                .ForMember(m => m.BankAccountViewModelList, opt => opt.MapFrom(x => x.BankAccounts))
                .ForMember(m => m.CustomerContactViewModelList, opt => opt.MapFrom(x => x.CustomerContacts))
                .ReverseMap();

                config.CreateMap<Document, DocumentViewModel>().ReverseMap();
                config.CreateMap<DocumentType, DocumentTypeViewModel>().ReverseMap();

                config.CreateMap<LoanDocument, DocumentViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Document.Name))
                .ForMember(m => m.Title, opt => opt.MapFrom(x => x.Document.Title))
                .ForMember(m => m.LoanId, opt => opt.MapFrom(x => x.LoanId))
                .ForMember(m => m.LoanViewModel, opt => opt.MapFrom(x => x.Loan))
                .ForMember(m => m.DocumentTypeViewModel, opt => opt.MapFrom(x => x.Document.DocumentType));

                config.CreateMap<CustomerDocument, DocumentViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Document.Name))
                .ForMember(m => m.Title, opt => opt.MapFrom(x => x.Document.Title))
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
                .ForMember(m => m.CustomerViewModel, opt => opt.MapFrom(x => x.Customer))
                .ForMember(m => m.DocumentTypeViewModel, opt => opt.MapFrom(x => x.Document.DocumentType));
                //.ForMember(m => m.CustomerViewModel, opt => opt.MapFrom(x => x.Customer));

            });
        }
    }
}
