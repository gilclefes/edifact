namespace Edifact.SpecifiedSegments
{
	public class GisSegment : Segment
	{
		public GisSegment()
		{ }
        public GisSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string ProcessIndicator { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		
		public override string Description
		{
			get
			{

                return ProcessIndicator;
			}
		}
	}
}
