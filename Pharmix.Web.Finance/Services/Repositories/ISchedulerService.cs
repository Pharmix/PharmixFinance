using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Pkcs;
using Pharmix.Data.Entities.Context;
using Pharmix.Web.Entities;
using Pharmix.Web.Models;
using Pharmix.Web.Models.SchedulerViewModels;
using X.PagedList;

namespace Pharmix.Web.Services.Repositories
{
    public interface ISchedulerService
    {
        EnityBoxViewModel GetEntitySearchResult(DateTime requestDate, string searchText, DateTime? dob, int departmentId, int page = 1, int pageSize = 10);
        GridBoxViewModel GetEntityHistory(int entityId, DateTime? fromDate, DateTime? toDate, int page = 1, int pageSize = 10);
        CalendarTimelineViewModel GetCalendarTimeline(DateTime date, Trust trust, int departmentId);
        object CreateAppointment(AppointmentDetailViewModel model, string user);
        AppointmentDetailViewModel CreateAppointmentDetailViewModel(int appointmentId, int entityId, DateTime appointmentDateTime, int departmentId);
        object CancelAppointment(AppointmentDetailViewModel model, string user);
        SchedulerEntityDetail GetEntityDetail(int entityId);
        AppointmentIntervalViewModel CreateAppointmentIntervalViewModel(Trust trust);
        object SaveAppointmentInterval(AppointmentIntervalViewModel model, string user);
    }

    public class SchedulerService : ISchedulerService
    {
        //public string AppointmentStartTime = "08:30";
        //public string AppointmentEndTime = "18:30";
        //private const int AppointmentIntervalInMin = 15; //Calender timeline appointment interval
        private readonly IRepository repository;
        private readonly ITrustService trustService;

        public SchedulerService(IRepository repository, ITrustService trustService)
        {
            this.repository = repository;
            this.trustService = trustService;
        }
        public EnityBoxViewModel GetEntitySearchResult(DateTime requestDate, string searchText, DateTime? dob, int departmentId, int page = 1, int pageSize = 10)
        {
            var model = new EnityBoxViewModel()
            {
                GridName = "EntityBoxResult",
                PagingRoute = "scheduler",
                PagingAction = "entitysearch",
                BackgroundIconCss = "fa fa-user-plus",
                IsBoxDraggable = true,
                ShowBodyContentOnHover = true,
            };

            var patAppointments = repository.GetContext().PatientAppointments.Include(p => p.Patient)
                .Where(p => p.DepartmentId == departmentId && p.AppointmentDateTime.Date.Equals(requestDate) && !p.IsArchived);

            var pats = repository.GetAll<Patient>().Where(p => !patAppointments.Any(a => a.PatientId== p.Id) && !p.IsArchived);
            
            var serviceRows = pats
                .Where(p => string.IsNullOrEmpty(searchText) || p.GetDisplayName().ToLowerInvariant().Contains(searchText.ToLowerInvariant()))
                .Where(p => !dob.HasValue || (p.DateOfBirth.HasValue && p.DateOfBirth.Value.Date == dob.Value))
                .Select(model.BindGridData);
            model.Rows = serviceRows.ToPagedList(page, pageSize);

            return model;
        }

        private static GridBoxRow BindHistoryGridData(PatientAppointment source)
        {
            var row = new GridBoxRow
            {
                IdentityValue = source.PatientAppointmentId,
                BoxHeading = string.Format("{0} | {1} | {2}", source.AppointmentDateTime.ToString("D"), source.AppointmentDateTime.ToString("HH:mm"), source.ArchivedDate.HasValue? "Cancelled":"Booked"),
                ColSize = 12,
                DefalutCollapse = true
            };

            row.BoxBodyDictionary.Add("Email", source.Patient.EmailAddress ?? "N/A");
            row.BoxBodyDictionary.Add("Contact No.", source.Patient.MobileNumber ?? "N/A");
            row.BoxBodyDictionary.Add("Address", source.Patient.GetFullAddress());
            row.BoxBodyDictionary.Add("Appointment Notes", source.AppointmentNotes??"N/A");
            row.BoxBodyDictionary.Add("Created Date", source.CreatedDate.ToShortDateString());
            if (source.ArchivedDate.HasValue)
            {
                row.BoxBodyDictionary.Add("Cancel Notes", source.CancelNotes ?? "N/A");
                row.BoxBodyDictionary.Add("Cancelled Date", source.ArchivedDate.Value.ToShortDateString());
            }
            
            return row;
        }
        public GridBoxViewModel GetEntityHistory(int entityId, DateTime? fromDate, DateTime? toDate, int page = 1, int pageSize = 10)
        {
            var gridModel = new GridBoxViewModel()
            {
                GridName = "GridBoxEntityResult",
                PagingRoute = "scheduler",
                PagingAction = "entityhistorysearch",
                BackgroundIconCss = "fa fa-history"
            };

            var patAppointments = repository.GetContext().PatientAppointments.Include(p => p.Patient)
                .Where(p => p.PatientId == entityId)
                .Where(p => (!fromDate.HasValue || p.AppointmentDateTime.Date >= fromDate) && (!toDate.HasValue || p.AppointmentDateTime.Date <= toDate))
                .OrderBy(p => p.AppointmentDateTime);

            gridModel.Rows = patAppointments.Select(BindHistoryGridData).ToPagedList(page, pageSize);

            return gridModel;
        }

        public static int GetAge(DateTime? birthday)
        {
            if (!birthday.HasValue) return 0;

            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Value.Year;
            if (now < birthday.Value.AddYears(age)) age--;

            return age;
        }
        
        public CalendarTimelineViewModel GetCalendarTimeline(DateTime date, Trust trust, int departmentId)
        {
            var model = new CalendarTimelineViewModel() { RequestDate = date, DepartmentId  = departmentId };
            
            if (trust == null)
            {
                model.IntervalNotDefined = true;
                return model;
            }

            var allApts = repository.GetContext().PatientAppointments
                .Include(p => p.Patient)//This entity type can be changed when using this scheduler for other type entities
                .Where(p => p.DepartmentId == departmentId && p.AppointmentDateTime.Date.Equals(date.Date));

            var appointments = allApts.Where(p => !p.IsArchived);
            
            var time = GetStartEndTime(trust, date.DayOfWeek);
            var appStartTime = DateTime.Parse(time.Item1); 
            var appEndTime = DateTime.Parse(time.Item2);

            do
            {
                var appDateTime = date.AddHours(appStartTime.Hour).AddMinutes(appStartTime.Minute);
                var appModel = new CalendarAppointment
                {
                    AppointmentTime = appStartTime.ToString("HH:mm"),
                    AppointmentDateTime = appDateTime.ToString("dd/MM/yyyy HH:mm"),
                    DisplayPropCount = 2
                };

                var app = appointments.FirstOrDefault(a => a.AppointmentDateTime == appDateTime);
                if (app != null)
                {
                    appModel.EntityDetail = new SchedulerEntityDetail
                    {
                        AppointmentId = app.PatientAppointmentId,
                        EntityId = app.PatientId??0,
                        EntityText = string.Format("{0} ({1}, {2})", app.Patient.GetDisplayName(), app.Patient.Gender != null? app.Patient.Gender.Name:"N/A", GetAge(app.Patient.DateOfBirth)),
                        IconCss = "fa fa-user-plus"
                    };
                    appModel.EntityDetail.DisplayProperties.Add("PAS", app.Patient.PasNumber);
                    appModel.EntityDetail.DisplayProperties.Add("NHS", app.Patient.NhsNumber);
                }

                model.Appointments.Add(appModel);

                appStartTime = appStartTime.AddMinutes(trust.AppointmentIntervalMins);
            } while (appStartTime <= appEndTime);

            //Cancelled apts
            foreach (var apt in allApts.Where(p => p.IsArchived))
            {
                var item = new SchedulerEntityDetail()
                {
                    AppointmentId = apt.PatientAppointmentId,
                    EntityId = apt.PatientId ?? 0,
                    EntityText = string.Format("{0} ({1}, {2})", apt.Patient.GetDisplayName(), apt.Patient.Gender != null ? apt.Patient.Gender.Name : "N/A", GetAge(apt.Patient.DateOfBirth)),
                    IconCss = "fa fa-user-plus",
                    AppointmentTime = apt.AppointmentDateTime.ToString("HH:mm")
                };
                item.DisplayProperties.Add("PAS", apt.Patient.PasNumber);
                item.DisplayProperties.Add("NHS", apt.Patient.NhsNumber);
                item.DisplayProperties.Add("Note", string.IsNullOrEmpty(apt.CancelNotes)?"N/A": apt.CancelNotes);

                model.CancelledAppointments.Add(item);
            }
           
            return model;
        }

        private static Tuple<string, string> GetStartEndTime(Trust trust, DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Friday:
                    return new Tuple<string, string>(trust.FridayOpenTiming, trust.FridayEndTiming);
                case DayOfWeek.Monday:
                    return new Tuple<string, string>(trust.MondayOpenTiming, trust.MondayEndTiming);
                case DayOfWeek.Saturday:
                    return new Tuple<string, string>(trust.SaturdayOpenTiming, trust.SaturdayEndTiming);
                case DayOfWeek.Sunday:
                    return new Tuple<string, string>(trust.SundayOpenTiming, trust.SundayEndTiming);
                case DayOfWeek.Thursday:
                    return new Tuple<string, string>(trust.ThursdayOpenTiming, trust.ThursdayEndTiming);
                case DayOfWeek.Tuesday:
                    return new Tuple<string, string>(trust.TuesdayOpenTiming, trust.TuesdayEndTiming);
                case DayOfWeek.Wednesday:
                    return new Tuple<string, string>(trust.WednesdayOpenTiming, trust.WednesdayEndTiming);
                
                default:
                    return new Tuple<string, string>(trust.MondayOpenTiming, trust.MondayOpenTiming);
            }
        }

        public object CreateAppointment(AppointmentDetailViewModel model, string user)
        {
            try
            {
                var app = new PatientAppointment()
                {
                    PatientId = model.EntityId,
                    AppointmentDateTime = model.AppointmentDateTime,
                    AppointmentNotes = model.AppointmentNotes,
                    DepartmentId = model.DepartmentId
                };

                app.SetCreateDetails(user);
                repository.SaveNew(app);
            }
            catch (Exception e)
            {
                return new { IsSuccess = false, Message = "Appointment creation failed. Please contact administrator." };
            }

            return new {IsSuccess = true, Message = "Appointment created successfully."};
        }

        public AppointmentDetailViewModel CreateAppointmentDetailViewModel(int appointmentId, int entityId, DateTime appointmentDateTime, int departmentId)
        {
            var model = new AppointmentDetailViewModel(){ IsModelEditable = true, AppointmentId = appointmentId, EntityId = entityId, AppointmentDateTime = appointmentDateTime };

            var dept = repository.GetById<Department>(departmentId);
            model.DepartmentId = dept.DepartmentId;

            var app = repository.GetContext().PatientAppointments
                .Include(p => p.Patient)
                .FirstOrDefault(p => p.PatientAppointmentId == appointmentId);

            var pat = app == null? repository.GetById<Patient>(entityId) : app.Patient;

            model.DisplayProperties.Add("Department", dept.DepartmentName);
            model.DisplayProperties.Add("Patient Name", pat.GetDisplayName());
            model.DisplayProperties.Add("Email", pat.EmailAddress ?? "N/A");
            model.DisplayProperties.Add("Contact No.", pat.MobileNumber ?? "N/A");

            if (app == null) return model;

            model.AppointmentNotes = app.AppointmentNotes;
            model.CancelNotes = app.CancelNotes;

            model.IsModelEditable = !app.IsArchived;

            return model;
        }

        public object CancelAppointment(AppointmentDetailViewModel model,  string user)
        {
            try
            {
                var app = repository.GetById<PatientAppointment>(model.AppointmentId);
                app.CancelNotes = model.CancelNotes;
                app.SetArchiveDetails(user);
                repository.SaveExisting(app);
            }
            catch (Exception e)
            {
                return new { IsSuccess = false, Message = "Appointment cancellation failed. Please contact administrator." };
            }

            return new { IsSuccess = true, Message = "Appointment cancelled successfully." };
        }

        public SchedulerEntityDetail GetEntityDetail(int entityId)
        {
            var pat = repository.GetById<Patient>(entityId);
            return new SchedulerEntityDetail(){ EntityId = entityId, EntityText = pat.GetDisplayName() };
        }

        public AppointmentIntervalViewModel CreateAppointmentIntervalViewModel(Trust trust)
        {
            var model = new AppointmentIntervalViewModel { IsModelEditable = false};

            if (trust == null) return model;

            model = Mapper.Map<Trust, AppointmentIntervalViewModel>(trust);
            model.IsModelEditable = true;
            model.TrustId = trust.Id;

            return model;
        }
        
        public object SaveAppointmentInterval(AppointmentIntervalViewModel model, string user)
        {
            var trust = trustService.GetTrustById(model.TrustId);

            if (trust == null) return new {IsSuccess = false, Message = "Appointment intervals save failed"};
            
            if (repository.GetContext().PatientAppointments.Any(p => !p.IsArchived))
            {
                return new { IsSuccess = false, Message = "One or more appointments have been scheduled. Intervals can be updated only when there is no appointments scheduled in the system." };
            }

            trust = Mapper.Map(model, trust);

            trust.SetUpdateDetails(user);
            repository.SaveExisting(trust);

            return new { IsSuccess = true, Message = "Appointment intervals saved successfully" };

        }
    }
}
