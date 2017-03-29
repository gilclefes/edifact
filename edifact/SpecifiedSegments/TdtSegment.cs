using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class TdtSegment : Segment
	{
		public TdtSegment()
		{ }
        public TdtSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string TransportStageCodeType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string ModeOfTransport { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
		public string CarrierCode { get { return base[5, 0] ?? ""; } set { base[5, 0] = value; } }
		public string CarrierName { get { return base[5, 3] ?? ""; } set { base[5, 3] = value; } }
      
		public override string Description
		{
			get
			{
				var sb = new StringBuilder(64);

                if (TransportStageCodeType.Length > 0)
                    sb.Append((sb.Length > 0 ? ", " : "") + "Id: " + TransportStageCodeType);
				
			

				return sb.ToString();
			}
		}
	}
}
