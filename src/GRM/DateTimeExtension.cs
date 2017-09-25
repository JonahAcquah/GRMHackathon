using System;
using System.Globalization;

namespace GRM
{
    public static class DateTimeExtension
    {
        public static DateTime ParseGrmExact(this string grmDateTime)
        {
            //TODO: Forgive me father. This is a sin.
            var cleanedDate = grmDateTime.Replace("st", string.Empty);
            cleanedDate = cleanedDate.Replace("th", string.Empty);

            DateTime.TryParseExact(cleanedDate.Trim(), "d MMM yyyy",
                                    CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal,
                                    out DateTime date);

            return date;
        }
    }
}
