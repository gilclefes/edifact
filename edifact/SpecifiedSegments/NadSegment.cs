using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact.SpecifiedSegments
{
	public class NadSegment : Segment
	{
		public NadSegment()
			: base()
		{ }
		public NadSegment(string segmentValue, char elementSeparator, char componentSeparator) :
			base(segmentValue, elementSeparator, componentSeparator)
		{

		}

		public string NadType { get { return base[1, 0]; } set { base[1, 0] = value; } }
		public string Identification { get { return base[2, 0]; } set { base[2, 0] = value; } }
		public string ResponsibleAgencyCode { get { return base[2, 2]; } set { base[2, 2] = value; } }
		public string Name1 { get { return base[4, 0]; } set { base[4, 0] = value; } }
		public string Name2 { get { return base[4, 1]; } set { base[4, 1] = value; } }
		public string Address1 { get { return base[5, 0]; } set { base[5, 0] = value; } }
		public string Address2 { get { return base[5, 1]; } set { base[5, 1] = value; } }
		public string Address3 { get { return base[5, 2]; } set { base[5, 2] = value; } }
		public string City { get { return base[6, 0]; } set { base[6, 0] = value; } }
		public string PostalCode { get { return base[8, 0]; } set { base[8, 0] = value; } }
		public string CountryCode { get { return base[9, 0]; } set { base[9, 0] = value; } }
	}
}
