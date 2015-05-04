using System;
using System.Globalization;

namespace Edifact.SpecifiedSegments
{
	public class DtmSegment : Segment
	{
		public DtmSegment()
			: base()
		{
			SetDate(new DateTime(1900, 1, 1), "102");
		}
		public DtmSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string DateType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public DateTime Date { get { return String2DateTime(base[1, 1], DateFormat); } }
		public string DateFormat { get { return base[1, 2]; } }

		public override string Description
		{
			get
			{
				switch (DateType)
				{
					case "137":
						return "Document date " + Date.ToShortDateString();
					default:
						return Date.ToShortDateString();
				}
			}
		}

		public static DateTime String2DateTime(string date, string format)
		{
			switch (format)
			{
				case "102":
					return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
				default:
					throw new Exception(string.Format("Invalid Date Format ({0})", format));
			}
		}
		public static string DateTime2String(DateTime date, string format)
		{
			switch (format)
			{
				case "102":
					return date.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
				default:
					throw new Exception(string.Format("Invalid Date Format ({0})", format));
			}
		}
		public void SetDate(DateTime date, string format)
		{
			base[1, 1] = DateTime2String(date, format);
			base[1, 2] = format;
		}

	}
}
