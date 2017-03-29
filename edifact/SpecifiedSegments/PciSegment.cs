namespace Edifact.SpecifiedSegments
{
	public class PciSegment : Segment
	{
		public PciSegment()
		{ }
        public PciSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string MarksandNumbers1 { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
        public string MarksandNumbers2 { get { return base[2, 1] ?? ""; } set { base[2, 1] = value; } }
        public string PakacgeStatus { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
		public override string Description
		{
			get
			{

                return MarksandNumbers1;
			}
		}
	}
}
