using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact
{
	class Element
	{
		internal Element()
		{
			Components = new List<Component>();
		}
		internal Element(string elementValue, char componentSeparator)
			: this()
		{
			// ToDo: Kontroller

			foreach (var componentValue in elementValue.Split(componentSeparator))
			{
				Components.Add(new Component() { Value = componentValue });
			}
		}

		public List<Component> Components { get; private set; }
		public string this[int componentIndex]
		{
			get { return Components[componentIndex].Value; }
			set
			{
				while (Components.Count < componentIndex + 1)
					Components.Add(new Component());
				Components[componentIndex].Value = value;
			}
		}

		public override string ToString()
		{
			return ToString(Settings.Default.ComponentSeparator);
		}
		public string ToString(char componentSeparator)
		{
			return string.Join(componentSeparator.ToString(), Components.Select(x => x.Value));
		}
	}
}
