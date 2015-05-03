using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact
{
	public class Component
	{
		public Component()
		{
			Value = "";
		}

		public string Value { get; internal set; }

		public override string ToString()
		{
			return Value;
		}
	}
}
