namespace Edifact.SpecifiedSegments
{
	public class PiaSegment : Segment
	{
		public PiaSegment()
		{ }
		public PiaSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }

		public string ProductIdentifierType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string Identification1 { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
		public string Identification1Type { get { return base[2, 1] ?? ""; } set { base[2, 1] = value; } }
		public string Identification2 { get { return base[3, 0] ?? ""; } set { base[3, 0] = value; } }
		public string Identification2Type { get { return base[3, 1] ?? ""; } set { base[3, 1] = value; } }
		public string Identification3 { get { return base[4, 0] ?? ""; } set { base[4, 0] = value; } }
		public string Identification3Type { get { return base[4, 1] ?? ""; } set { base[4, 1] = value; } }

		public override string Description
		{
			get
			{
				for (int segmentIndex = 2; segmentIndex <= 4; segmentIndex++)
				{
					var id = base[segmentIndex, 0];
					var type = base[segmentIndex, 1];
					if (id.Length > 0)
					{
						switch (type)
						{
							case "SA":
								return "Supplier Stock Id: " + id;
							default:
								return id;
						}
					}
				}
				return "";
			}
		}
	}
}
