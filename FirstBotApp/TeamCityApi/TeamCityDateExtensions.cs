using System;
using System.Globalization;

namespace TeamCityApi
{
    public static class TeamCityDateExtensions
    {
        private const string DateFormat = "yyyyMMddTHHmmsszz00";

       public static bool TryParseDate(string date, out DateTime value)
        {
            return DateTime.TryParseExact(date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
        }

        public static string FormatDate(DateTime value)
        {
            return value.ToString(DateFormat);
        }
    }
}