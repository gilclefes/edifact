using System;
using System.Globalization;

namespace Edifact
{
    static class DateHelper
	{
        public static DateTime String2DateTime(string date, string format)
        {
            switch (format)
            {
                case "102":
                    return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                case "ddmmyy":
                    return DateTime.ParseExact(date, "ddmmyy", CultureInfo.InvariantCulture);
                default:
                    return DateTime.Now;
            }
        }
	}
}
