
namespace Edifact.SpecifiedSegments
{
	public class QtySegment : Segment
	{
		public QtySegment()
			: base()
		{ }
		public QtySegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{ }
		public string QtyType { get { return base[1, 0] ?? ""; } set { base[1, 0] = value; } }
		public int Qty
		{
			get
			{
				int v;
				if (int.TryParse(base[1,1], out v))
					return v;
				return 0;
			}
			set { base[1, 1] = value.ToString(); }
		}

		public override string Description
		{
			get
			{
				switch (QtyType)
				{
					case "21":
						return "Ordered quantity: " + Qty.ToString();
					default:
						return "Quantity: " + Qty.ToString();
				}
			}
		}
	}
}
