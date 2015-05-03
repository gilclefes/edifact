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
			return Value;
		}
	}
}
