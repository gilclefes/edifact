using System.Collections.Generic;
using System.Linq;

namespace Edifact
{
	public class Segment
	{
		internal Segment()
		{
			Elements = new List<Element>();
		}
		internal Segment(string segmentValue, char elementSeparator, char componentSeparator)
			: this()
		{
			// ToDo: Kontroller

			foreach (var elementValue in segmentValue.Split(elementSeparator))
			{
				Elements.Add(new Element(elementValue, componentSeparator));
			}
		}

		public List<Element> Elements { get; private set; }
		public string Tag { get { return this[0, 0]; } }

		public Element this[int elementIndex] { get { return Elements[elementIndex]; } }
		public string this[int elementIndex, int componentIndex]
		{
			get
			{
				if (elementIndex >= Elements.Count)
					return null;
				return Elements[elementIndex][componentIndex];
			}
			set
			{
				while (Elements.Count < elementIndex + 1)
					Elements.Add(new Element());
				Elements[elementIndex][componentIndex] = value;
			}
		}
		public virtual string Description { get { return ""; } }

		public override string ToString()
		{
			return ToString(new Settings());
		}
		public string ToString(ISettings settings)
		{
			return string.Join(settings.ElementSeparator.ToString(), Elements.Select(x => x.ToString(settings)));
		}
	}
}
