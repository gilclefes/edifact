using System;
using System.Text;
using System.Text.RegularExpressions;
namespace Edifact
{
	public interface ISettings
	{
		char ComponentSeparator { get; }
		char ElementSeparator { get; }
		char DecimalMark { get; }
		char EscapeCharacter { get; }
		char SegmentTerminator { get; }
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
			ComponentSeparator = DEFAULT_COMPONENT_SEPARATOR;
			ElementSeparator = DEFAULT_ELEMENT_SEPARATOR;
			DecimalMark = DEFAULT_DECIMAL_MARK;
			EscapeCharacter = DEFAULT_ESCAPE_CHARACTER;
			SegmentTerminator = DEFAULT_SEGMENT_TERMINATOR;
		}

		public string GetUnaSegment()
		{
			var sb = new StringBuilder(8);
			sb.Append("UNA");
			sb.Append(ComponentSeparator);
			sb.Append(ElementSeparator);
			sb.Append(DecimalMark);
			sb.Append(EscapeCharacter);
			sb.Append(' ');
			sb.Append(SegmentTerminator);
			return sb.ToString();
		}

		// Settings from UNA
		public char ComponentSeparator { get; set; }
		public char ElementSeparator { get; set; }
		public char DecimalMark { get; set; }
		public char EscapeCharacter { get; set; }
		public char SegmentTerminator { get; set; }

	}
}
