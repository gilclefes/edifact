using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact.SpecifiedSegments
{
	public class RffSegment : Segment
	{
		public RffSegment()
			: base()
		{ }
		public RffSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string QualifierCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string Identifier { get { return base[1, 1] ?? ""; } set { base[1, 1] = value; } }
		public string DocumentLineIdentifier { get { return base[1, 2] ?? ""; } set { base[1, 2] = value; } }

		public override string Description
		{
			get
			{
				switch (QualifierCode)
				{
					case "VA":
						return "Vat number: " + Identifier;
					default:
						return "Reference: " + Identifier;
				}
			}
		}
	}
}
