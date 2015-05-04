
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
		public int Qty
		{
			get
			{
				int v;
				if (int.TryParse(base[1, 0], out v))
					return v;
				return 0;
			}
			set { base[1, 0] = value.ToString(); }
		}
	}
}
