using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact.SpecifiedSegments
{
	public class CuxSegment : Segment
	{
		public CuxSegment()
			: base()
		{
		}
		public CuxSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string UsageQualifierCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string IdentificationCode { get { return base[1, 1] ?? ""; } set { base[1, 1] = value; } }
		public string TypeQualifierCode { get { return base[1, 2] ?? ""; } set { base[1, 2] = value; } }

		public override string Description
		{
			get
			{
				if (TypeQualifierCode == "4")
					return "Invoice currency: " + IdentificationCode;
				else
					return "Currency: " + IdentificationCode;
			}
		}
	}
}
