namespace Edifact.SpecifiedSegments
{
	public class ImdSegment : Segment
	{
		public ImdSegment()
		{
		}
		public ImdSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string FormatCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string ItemDescription { get { return base[3, 3] ?? ""; } set { base[3, 3] = value; } }

		public override string Description
		{
			get
			{
				switch (FormatCode)
				{
					case "A":
						return "Free-form long description";

					case "B":
						return "Code and text";

					case "C":
						return "Code (from industry code list)";

					case "D":
						return "Free-form price look up";

					case "E":
						return "Free-form short description";

					case "F":
						return "Free-form";

					case "S":
						return "Structured (from industry code list)";

					case "X":
						return "Semi-structured (code + text)";

					default:
						return base.Description;
				}
			}
		}
	}
}
