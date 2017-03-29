namespace Edifact.SpecifiedSegments
{
	public class MoaSegment : Segment
	{
		private readonly char _decimalPoint;
		public MoaSegment(char decimalPoint)
		{
			_decimalPoint = decimalPoint;
		}
		public MoaSegment(string segmentValue, char elementSeparator, char componentSeparator, char decimalPoint) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
			_decimalPoint = decimalPoint;
		}

		public string MonetaryType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }

        public string MonetaryCurrency { get { return base[1, 2] ?? ""; } set { base[1, 2] = value; } }
		public decimal MonetaryAmount
		{
			get { return Helper.Str2Dec(base[1, 1], _decimalPoint); }
			set { base[1, 0] = Helper.Dec2Str(value, _decimalPoint); }
		}

		public override string Description
		{
			get
			{
				switch (MonetaryType)
				{
					case "9":
						return "Payable amount: " + MonetaryAmount.ToString("N2");
					case "77":
						return "Invoice amount: " + MonetaryAmount.ToString("N2");
					case "79":
						return "Total line items amount: " + MonetaryAmount.ToString("N2");
					case "124":
						return "Tax amount: " + MonetaryAmount.ToString("N2");
					case "125":
						return "Taxable amount: " + MonetaryAmount.ToString("N2");
					case "176":
						return "Total duty/tax/fee amount: " + MonetaryAmount.ToString("N2");
					case "203":
						return "Line item amount: " + MonetaryAmount.ToString("N2");
					case "165":
						return "Rounding: " + MonetaryAmount.ToString("N2");
					default:
						return MonetaryAmount.ToString("N2");
				}
			}
		}
	}
}
