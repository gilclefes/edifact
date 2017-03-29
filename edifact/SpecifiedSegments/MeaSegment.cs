using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class MeaSegment : Segment
	{
        public MeaSegment()
		{ }
        public MeaSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string MeasurementCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
        public string MeasurementAttributeCode { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
        public string MeasurementUnitCode { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
        public decimal MeasurementValue
        {
            get
            {
                decimal v;
                if (decimal.TryParse(base[3, 1], out v))
                    return v;
                return 0;
            }
            set { base[3, 1] = value.ToString("N"); }
        }
	
		public override string Description
		{
			get
			{
				var sb = new StringBuilder(64);

                if (MeasurementCode.Length > 0)
                    sb.Append((sb.Length > 0 ? ", " : "") + "Id: " + MeasurementCode);							

				return sb.ToString();
			}
		}
	}
}
