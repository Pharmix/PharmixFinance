using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmix.Data.Enums
{
    public enum GenderEnum
    {
        None,
        Male,
        Female,
        Transgender
    }
    public enum RecurringTypeEnum
    {
        NoRecurring = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    }

    public enum DailyRecurringTypeEnum
    {
        NoRecurring = 0,
        Everyday = 1,
        EveryWeekday = 2,
    }

    public enum StatusEnum
    {
        None = 0,
        Pending = 1,
        Approved = 2,
        Archived = 3
    }

    public enum RequsetPriorityEnum
    {
        VeryHigh = 1,
        High = 2,
        Medium = 3,
        Low = 4,
        VeryLow = 5
    }

    public enum RequestStatusEnum
    {
        Awaiting = 1,
        Approved = 2,
        SentForReview = 3,
        Declined = 4
    }

    public enum OrderProgressEnum
    {
        New = 1,
        Pending = 2,
        Approved = 3,
        Scheduled = 4,
        PreperationScheduled = 5,
        Compounding = 6,
        Completed = 7,
        Dispatched = 8
    }

    public enum OrderPreperationStatusEnum
    {
        YetToStart = 0,
        Started = 1,
        Paused = 2,
        Completed = 3
    }

    public enum PriorityEnum
    {
        Critical = 1,
        High = 2,
        Medium = 3,
        Low = 4
    }

    public enum PressureUnitEnum
    {
        Pascal = 1,
        Bar = 2
    }

    public enum TemperatureUnitEnum
    {
        Celcius = 1,
        Farenheit = 2
    }

    public enum IsolatorOperationTypeEnum
    {
        ManualClosed = 1,
        AutomaticOpen = 2
    }

    public enum IsolatorProcedureTypeEnum
    {
        Start = 1,
        Stop = 2
    }

    public enum MarriageStatusEnum
    {
        Single = 1,
        Married = 2,
        Partner = 3,
        Separated = 4,
        Divorce = 5,
        Widowed = 6
    }

    public enum EthnicOriginOwnEnum
    {
        You = 1,
        BabysFather = 2
    }

    public enum LoanStatusEnum
    {
        Created = 1,
        BeingReviewed,
        Approved,
        Rejected,
        PaidOut,
        Closed
    }

    public enum DocumentTypeEnum
    {
        PDF=1,
        DOCX=2,
        XLSX=3,
        TXT=4,
        ZIP=5,
        IMAGE=6,
        PNG=7,
        JPG=8,
        JPEG=9,
        FILE=10,
        PPT = 11,
        PPTX = 12
    }

}
