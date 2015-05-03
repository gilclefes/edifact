namespace Edifact
{
	public interface ISettings
	{
		char EscapeCharacter { get;  }
		char DecimalMark { get;  }
		char SegmentTerminator { get;  }
		char ElementSeparator { get;  }
		char ComponentSeparator { get;  }
	}
	public class Settings : ISettings
	{
		internal const char DEFAULT_ESCAPE_CHARACTER = '?';
		internal const char DEFAULT_DECIMAL_MARK = '.';
		internal const char DEFAULT_SEGMENT_TERMINATOR = '\'';
		internal const char DEFAULT_ELEMENT_SEPARATOR = '+';
		internal const char DEFAULT_COMPONENT_SEPARATOR = ':';

		public Settings()
		{
			EscapeCharacter = DEFAULT_ESCAPE_CHARACTER;
			DecimalMark = DEFAULT_DECIMAL_MARK;
			SegmentTerminator = DEFAULT_SEGMENT_TERMINATOR;
			ElementSeparator = DEFAULT_ELEMENT_SEPARATOR;
			ComponentSeparator = DEFAULT_COMPONENT_SEPARATOR;
		}

		// Settings from UNA
		public char EscapeCharacter { get; set; }
		public char DecimalMark { get; set; }
		public char SegmentTerminator { get; set; }
		public char ElementSeparator { get; set; }
		public char ComponentSeparator { get; set; }

	}
}
