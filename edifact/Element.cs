using System.Collections.Generic;
using System.Linq;

namespace Edifact
{
	public class Element
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
			get
			{
				if (componentIndex >= Components.Count)
					return null;
				return Components[componentIndex].Value;
			}
			set
			{
				while (Components.Count < componentIndex + 1)
					Components.Add(new Component());
				Components[componentIndex].Value = value;
			}
		}

		public override string ToString()
		{
			return ToString(new Settings());
		}
		public string ToString(ISettings settings)
		{
			return string.Join(settings.ComponentSeparator.ToString(), Components.Select(x => x.ToString(settings)));
		}
	}
}
