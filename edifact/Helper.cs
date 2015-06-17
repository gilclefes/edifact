using System.Globalization;

namespace Edifact
{
	static class Helper
	{
		public static decimal Str2Dec(string value, char decimalPoint)
		{
			decimal v;

			// Replace (eventually) the string to en-US decimal point
			string val = value.Replace(decimalPoint, '.');

			// Try to parse as en-US format (As it should be at the moment)
			if (decimal.TryParse(val, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out v))
				return v;

			// if not able to parce, return default value (0)
			return default(decimal);
		}
		public static string Dec2Str(decimal value, char decimalPoint)
		{
			// Format decimal value to string in en-US format
			string val = value.ToString(CultureInfo.GetCultureInfo("en-US"));

			// Return the value, where the en-US decimal point is replaced (eventually)
			return val.Replace('.', decimalPoint);
		}
	}
}
