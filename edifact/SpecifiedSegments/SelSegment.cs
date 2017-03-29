using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class SelSegment : Segment
	{
		public SelSegment()
		{ }
        public SelSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string SealValue { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
	
	
		public override string Description
		{
			get
			{
				return SealValue;
			    ;
			}
		}
	}
}
