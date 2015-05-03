using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact.SpecifiedSegments
{
	class DtmSegment : Segment
	{
		public DtmSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
			DateType = base[1, 0];
			DateFormat = base[1, 2];

			switch (DateFormat)
			{
				case "102":
					DateValue = DateTime.ParseExact(base[1, 1], "yyyyMMdd", CultureInfo.InvariantCulture);
					break;
				default:
					throw new Exception(string.Format("Invalid Date Format ({0}) in segment {1}", DateFormat, segmentValue));
			}

		}

		public string DateType { get; private set; }
		public DateTime DateValue { get; private set; }
		public string DateFormat { get; private set; }
		
	}
}
