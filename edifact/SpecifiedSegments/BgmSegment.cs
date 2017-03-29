using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class BgmSegment : Segment
	{
		public BgmSegment()
		{ }
        public BgmSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string CodeType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string DocumentName { get { return base[1, 3] ?? ""; } set { base[1, 3] = value; } }
		public string DocumentNumber { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
		public string MessageType { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
      
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
