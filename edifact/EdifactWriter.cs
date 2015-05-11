using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Edifact
{
	public static class EdifactWriter
	{
		public static void WriteFile(ISettings settings, List<Segment> segments, FileInfo fi, Encoding enc)
		{
			using (var f = new StreamWriter(fi.FullName, false, enc))
			{
				f.Write(WriteData(settings, segments));
			}
		}
		public static string WriteData(ISettings settings, IEnumerable<Segment> segments)
		{
			var result = new StringBuilder(512);

			foreach (var sgmnt in segments)
			{
				if (result.Length > 0)
					result.AppendLine();
				result.Append(sgmnt.ToString(settings));
				result.Append(settings.SegmentTerminator);				
			}

			return result.ToString();
		}
	}
}
