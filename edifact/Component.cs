using System.Text;
namespace Edifact
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
			return ToString(new Settings());
		}
		public string ToString(ISettings settings)
		{
			var sb = new StringBuilder(Value.Length + 1);
			foreach (var c in Value)
			{
				if (c == settings.EscapeCharacter || c == settings.SegmentTerminator || c == settings.ElementSeparator || c == settings.ComponentSeparator)
					sb.Append(settings.EscapeCharacter);
				sb.Append(c);
			}
			return sb.ToString();
		}
	}
}
