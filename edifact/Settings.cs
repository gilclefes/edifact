using System;
using System.Text;
using System.Text.RegularExpressions;
namespace Edifact
{
	public interface ISettings
	{
		string UnaSegment { get; }
		char ComponentSeparator { get; }
		char ElementSeparator { get; }
		char DecimalMark { get; }
		char EscapeCharacter { get; }
		char SegmentTerminator { get; }
	}
	public class Settings : ISettings
	{
		private char[] _unaSegment;

		public Settings()
		{
			UnaSegment = "UNA:+.? '";
		}

		// UNA
		public string UnaSegment
		{
			get { return new string(_unaSegment); }
			set
			{
				if (!Regex.IsMatch(value, "^UNA......$"))
					throw new ArgumentException("value", "Not valid segment får UNA");
				_unaSegment = value.ToCharArray();
			}
		}
		public char ComponentSeparator { get { return _unaSegment[3]; } set { _unaSegment[3] = value; } }
		public char ElementSeparator { get { return _unaSegment[4]; } set { _unaSegment[4] = value; } }
		public char DecimalMark { get { return _unaSegment[5]; } set { _unaSegment[5] = value; } }
		public char EscapeCharacter { get { return _unaSegment[6]; } set { _unaSegment[6] = value; } }
		public char SegmentTerminator { get { return _unaSegment[8]; } set { _unaSegment[8] = value; } }

	}
}
