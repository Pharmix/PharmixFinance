using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Data.Enums;
using Pharmix.Web.Entities;
using X.PagedList;

namespace Pharmix.Web.Models.SchedulerViewModels
{
    public class SchedulerViewModel
    {
        public SearchViewModel EntitySearch { get; set; } = new SearchViewModel();
        public string Title { get; set; }
        public string PageHeader { get; set; }
        public DateTime CalendarBeginDate { get; set; } = DateTime.Today;
        public bool EnableIntervalConfig { get; set; }
        public int DepartmentId { get; set; }
        public SelectList Departments { get; set; }
    }

    public class AppointmentDetailViewModel
    {
        public DateTime AppointmentDateTime { get; set; }
        public int AppointmentId { get; set; }
        public int EntityId { get; set; }
        public int DepartmentId { get; set; }
        public IDictionary<string, string> DisplayProperties { get; set; } = new Dictionary<string, string>();
        public string AppointmentNotes { get; set; }
        public string CancelNotes { get; set; }
        public bool IsModelEditable { get; set; }
        public bool IsRecurring { get; set; }
        public CalenderRecurrenceViewModel RecurrenceModel { get; set; }
    }

    public class CalenderRecurrenceViewModel
    {
        public bool IsRecurring { get; set; }
        public RecurringTypeEnum RecurringType { get; set; } = RecurringTypeEnum.Daily;
        public DateTime? RecurrenceEndDate { get; set; }
        public DailyRecurringTypeEnum DailyRecurringType { get; set; } = DailyRecurringTypeEnum.EveryWeekday;
        public MultiSelectList DayList { get; set; }
        public int[] SelectedDays { get; set; }
        public bool IsModelReadonly { get; set; }
    }

    public class CalendarTimelineViewModel
    {
        public DateTime RequestDate { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<CalendarAppointment> Appointments { get; set; } = new List<CalendarAppointment>();
        public List<SchedulerEntityDetail> CancelledAppointments { get; set; } = new List<SchedulerEntityDetail>();
        public bool IntervalNotDefined { get; set; }
        public bool EnableIntervalConfig { get; set; }
    }

    public class CalendarAppointment
    {
        public string AppointmentTime { get; set; }
        public string AppointmentDateTime { get; set; }
        public SchedulerEntityDetail EntityDetail { get; set; }
        public int DisplayPropCount { get; set; }
    }

    public class AppointmentIntervalViewModel
    {
        public int TrustId { get; set; }
        //public bool IsSundaySelected { get; set; }
        //public bool IsMondaySelected { get; set; }
        //public bool IsTuesdaySelected { get; set; }
        //public bool IsWednesdaySelected { get; set; }
        //public bool IsThursdaySelected { get; set; }
        //public bool IsFridaySelected { get; set; }
        //public bool IsSaturdaySelected { get; set; }

        public string MondayOpenTiming { get; set; }
        public string TuesdayOpenTiming { get; set; }
        public string WednesdayOpenTiming { get; set; }
        public string ThursdayOpenTiming { get; set; }
        public string FridayOpenTiming { get; set; }
        public string SaturdayOpenTiming { get; set; }
        public string SundayOpenTiming { get; set; }
        public string MondayEndTiming { get; set; }
        public string TuesdayEndTiming { get; set; }
        public string WednesdayEndTiming { get; set; }
        public string ThursdayEndTiming { get; set; }
        public string FridayEndTiming { get; set; }
        public string SaturdayEndTiming { get; set; }
        public string SundayEndTiming { get; set; }
        public int AppointmentIntervalMins { get; set; }
        public bool IsModelEditable { get; set; }
    }

    public class SchedulerEntityDetail
    {
        public int AppointmentId { get; set; }
        public int EntityId { get; set; }
        public string EntityText { get; set; }
        public string IconCss { get; set; }
        public string AppointmentTime { get; set; }
        public IDictionary<string, string> DisplayProperties { get; set; } = new Dictionary<string, string>();
    }

    public class EnityBoxViewModel
    {
        public string GridName { get; set; } = "EntityBoxResult";
        public IPagedList<EntityBoxRow> Rows { get; set; }
        public string PagingRoute { get; set; }
        public string PagingAction { get; set; }
        public string DefaultSortColum { get; set; }
        public bool HideFooter { get; set; }
        public string BackgroundIconCss { get; set; }
        public bool IsBoxDraggable { get; set; }
        public bool ShowBodyContentOnHover { get; set; }
        
        public EntityBoxRow BindGridData(Patient source)
        {
            var row = new EntityBoxRow
            {
                IdentityValue = source.Id,
                BoxHeading = source.GetDisplayName()
            };

            row.BoxBodyDictionary.Add("NHS no.", string.IsNullOrEmpty(source.NhsNumber)?"N/A": source.NhsNumber);
            row.BoxBodyDictionary.Add("Date of bith", source.DateOfBirth.HasValue? source.DateOfBirth.Value.ToShortDateString():"N/A");
            row.BoxBodyDictionary.Add("Address", source.GetFullAddress());

            return row;
        }
    }

    public class EntityBoxRow
    {
        public EntityBoxRow()
        {
            BoxBodyDictionary = new Dictionary<string, string>();
            DataAttriDictionary = new Dictionary<string, string>();
        }
        public int IdentityValue { get; set; }

        public string BoxHeading { get; set; }

        public IDictionary<string, string> BoxBodyDictionary { get; set; }

        public IDictionary<string, string> DataAttriDictionary { get; set; }
    }
}
