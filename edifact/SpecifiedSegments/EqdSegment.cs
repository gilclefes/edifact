namespace Edifact.SpecifiedSegments
{
	public class EqdSegment : Segment
	{
		public EqdSegment()
		{ }
        public EqdSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string EquipmentTypeCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }

	    public string EquipmentCode
	    {
	        get { return base[2, 0] ?? ""; }
	        set { base[2, 0] = value; }
	    }

	    public string EquipmentFullStatusCode { get { return base[6, 0] ?? ""; } set { base[6, 0] = value; } }
        public string EquipmentSize { get { return base[3, 3] ?? ""; } set { base[3, 3] = value; } }

		public override string Description
		{
			get
			{

                return EquipmentCode;
					
			}
		}
	}
}
