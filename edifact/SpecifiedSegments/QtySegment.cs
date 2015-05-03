using EdifactViewer.Edifact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edifact.SpecifiedSegments
{
	public class QtySegment : Segment
	{
		public QtySegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
			Qty = int.Parse(base[1, 1]);
		}
		public int Qty { get; private set; }
	}
}
