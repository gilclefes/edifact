using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class UnbSegment : Segment
	{
		public UnbSegment()
		{ }
        public UnbSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string Identification { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string sender { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
		public string receipient { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
		public string version { get { return base[1, 1] ?? ""; } set { base[1, 1] = value; } }
        public DateTime Date { get { return DateHelper.String2DateTime(base[4, 0], "ddmmyy"); } }

		public override string Description
		{
			get
			{
				var sb = new StringBuilder(64);
				
				if (Identification.Length > 0)
					sb.Append((sb.Length > 0 ? ", " : "") + "Id: " + Identification);
				
			

				return sb.ToString();
			}
		}
	}
}
