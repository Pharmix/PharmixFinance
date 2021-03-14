using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime != null ? dateTime.ToString("dd-MM-yyyy") : string.Empty;
        }
        public static string ToCustomDateTimeString(this DateTime dateTime)
        {
            return dateTime != null ? dateTime.ToString("dd-MM-yyyy hh:mm") : string.Empty;
        }
    }
}
