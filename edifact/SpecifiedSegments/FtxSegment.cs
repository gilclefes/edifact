using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class FtxSegment : Segment
	{
		public FtxSegment()
		{ }
        public FtxSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string CodeType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string TextValue { get { return base[4,0] ?? ""; } set { base[4,0] = value; } }
        public string TextValue1 { get { return base[4, 1] ?? ""; } set { base[4, 1] = value; } }
	
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
