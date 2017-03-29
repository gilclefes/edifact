using System;
using System.Text;

namespace Edifact.SpecifiedSegments
{
	public class GidSegment : Segment
	{
		public GidSegment()
		{ }
        public GidSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string ItemNo { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
        public int PackageQuantity
        {
            get
            {
                int v;
                if (int.TryParse(base[2, 0], out v))
                    return v;
                return 0;
            }
            set { base[2, 0] = value.ToString(); }
        }
		public string PackageType { get { return base[2, 1] ?? ""; } set { base[2, 1] = value; } }
		
      
		public override string Description
		{
			get
			{
				var sb = new StringBuilder(64);

                if (ItemNo.Length > 0)
                    sb.Append((sb.Length > 0 ? ", " : "") + "Id: " + ItemNo);
				
			

				return sb.ToString();
			}
		}
	}
}
