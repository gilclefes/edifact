using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact.SpecifiedSegments
{
	public class MoaSegment : Segment
	{
		private readonly char _decimalPoint;
		public MoaSegment(char decimalPoint)
			: base()
		{
			_decimalPoint = decimalPoint;
		}
		public MoaSegment(string segmentValue, char elementSeparator, char componentSeparator, char decimalPoint) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
			_decimalPoint = decimalPoint;
		}

		public string MonetaryType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
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
