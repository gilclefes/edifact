using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact
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
				return Elements[elementIndex][componentIndex];
			}
			set
			{
				while (Elements.Count < elementIndex + 1)
					Elements.Add(new Element());
				Elements[elementIndex][componentIndex] = value;
			}
		}

		public override string ToString()
		{
			return ToString(Settings.DEFAULT_ELEMENT_SEPARATOR, Settings.DEFAULT_COMPONENT_SEPARATOR);
		}
		public string ToString(char elementSeparator, char componentSeparator)
		{
			return string.Join(elementSeparator.ToString(), Elements.Select(x => x.ToString(componentSeparator)));
		}
	}
}
