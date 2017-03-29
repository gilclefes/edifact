using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class LocSegment : Segment
	{
		public LocSegment()
		{ }
        public LocSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string CodeType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string LocationCode { get { return base[2, 0] ?? ""; } set { base[2,0] = value; } }
		public string LocationName { get { return base[2, 3] ?? ""; } set { base[2, 3] = value; } }
      
		public override string Description
		{
			get
			{
				var sb = new StringBuilder(64);

                if (CodeType.Length > 0)
                    sb.Append((sb.Length > 0 ? ", " : "") + "Id: " + CodeType);
				
			

				return sb.ToString();
			}
		}
	}
}
