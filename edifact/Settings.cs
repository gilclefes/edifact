using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact
{
	class Settings
	{
		private static Settings _default;

		public Settings()
		{
			EscapeCharacter = '?';
			DecimalMark = '.';
			SegmentTerminator = '\'';
			ElementSeparator = '+';
			ComponentSeparator = ':';
		}

		public static Settings Default { get { return _default ?? (_default = new Settings()); } }

		// Settings from UNA
		public char EscapeCharacter { get; set; }
		public char DecimalMark { get; set; }
		public char SegmentTerminator { get; set; }
		public char ElementSeparator { get; set; }
		public char ComponentSeparator { get; set; }

	}
}
