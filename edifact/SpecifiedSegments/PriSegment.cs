namespace Edifact.SpecifiedSegments
{
	public class PriSegment : Segment
	{
		private readonly char _decimalPoint;
		public PriSegment(char decimalPoint)
		{
			_decimalPoint = decimalPoint;
		}
		public PriSegment(string segmentValue, char elementSeparator, char componentSeparator, char decimalPoint) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
			_decimalPoint = decimalPoint;
		}

		public string PriceCode { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public decimal PriceAmount
		{
			get { return Helper.Str2Dec(base[1, 1], _decimalPoint); }
			set { base[1, 0] = Helper.Dec2Str(value, _decimalPoint); }
		}
		public string PriceType { get { return base[1, 2] ?? ""; } set { base[1, 2] = value; } }
		public string PriceSpecification { get { return base[1, 3] ?? ""; } set { base[1, 3] = value; } }

		public override string Description
		{
			get
			{
				if (PriceCode == "AAA" && PriceSpecification == "CP")
					return "Current net price: " + PriceAmount.ToString("N2");
				else if (PriceCode == "AAA")
					return "Net price: " + PriceAmount.ToString("N2");
				else if (PriceSpecification == "CP")
					return "Current price: " + PriceAmount.ToString("N2");
				else
					return PriceAmount.ToString("N2");
			}
		}
	}
}
