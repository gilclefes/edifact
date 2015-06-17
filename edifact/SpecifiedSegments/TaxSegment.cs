namespace Edifact.SpecifiedSegments
{
	public class TaxSegment : Segment
	{
		public TaxSegment()
		{
		}
		public TaxSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public string FunctionQualifierCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public string TypeCodeName { get { return base[2, 0] ?? ""; } set { base[2, 0] = value; } }
		public string RateDescription { get { return base[5, 3] ?? ""; } set { base[5, 3] = value; } }

		public override string Description
		{
			get
			{
				var trimmedRateDescription = RateDescription;
				if (trimmedRateDescription.Contains("."))
					trimmedRateDescription = trimmedRateDescription.TrimEnd('0').TrimEnd('.');

				if (FunctionQualifierCode == "7" && TypeCodeName == "VAT")
					return "Value added tax: " + trimmedRateDescription + "%";
				else
					return base.Description;
			}
		}
	}
}
