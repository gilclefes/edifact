using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact.SpecifiedSegments
{
	public class LinSegment : Segment
	{
		public LinSegment()
			: base()
		{
		}
		public LinSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{
		}

		public int LineNumber
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
		public string Identifier { get { return base[3, 0]; } set { base[3, 0] = value; } }
		public string IdentifierType { get { return base[3, 1]; } set { base[3, 1] = value; } }
	}
}
