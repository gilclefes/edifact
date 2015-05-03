﻿using edifact.SpecifiedSegments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.Edifact
{
	public static class EdifactReader
	{
		public static ReaderResult ReadFile(FileInfo fi)
		{
			string data;

			using (var f = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(f))
			{
				data = reader.ReadToEnd();
			}

			return ReadData(data);
		}
		public static ReaderResult ReadData(string data)
		{
			Settings settings;
			List<Segment> segments;

			if (data.StartsWith("UNA"))
			{
				settings = new Settings()
				{
					ComponentSeparator = data[3],
					ElementSeparator = data[4],
					DecimalMark = data[5],
					EscapeCharacter = data[6],
					// 7 must be blank
					SegmentTerminator = data[8]
				};
			}
			else
			{
				settings = new Settings();
			}

			segments = new List<Segment>(ExtractSegments(data, settings));

			return new ReaderResult()
			{
				Settings = settings,
				Segments = segments
			};
		}
		private static IEnumerable<Segment> ExtractSegments(string data, Settings settings)
		{
			var segmentBuilder = new StringBuilder(32);

			for (int i = 0; i < data.Length; i++)
			{
				char c = data[i];

				// Blank, Tab, LF, CR
				if (c == ' ' || (int)c == 9 || (int)c == 10 || (int)c == 13)
				{
					// Skip character
				}
				else if (c == settings.EscapeCharacter)
				{
					i++;
					if (i >= data.Length)
						throw new Exception("Escape character at last position!");
					// Force upcomming character to the segment
					segmentBuilder.Append(data[i]);
				}
				else if (c == settings.SegmentTerminator)
				{
					var segmentValue = segmentBuilder.ToString();
					segmentBuilder.Length = 0;
					yield return CreateSegment(settings, segmentValue);
				}
				else
				{
					segmentBuilder.Append(c);
				}
			}

			if (segmentBuilder.Length > 0)
				throw new Exception("Segment with no terminator!");
		}

		private static Segment CreateSegment(Settings settings, string segmentValue)
		{
			switch (segmentValue.Substring(0, 3))
			{
				case "DTM":
					return new DtmSegment(segmentValue, settings.ElementSeparator, settings.ComponentSeparator);
				
				case "QTY":
					return new QtySegment(segmentValue, settings.ElementSeparator, settings.ComponentSeparator);

				default:
					return new Segment(segmentValue, settings.ElementSeparator, settings.ComponentSeparator);
			}
		}

	}

	public class ReaderResult
	{
		public List<Segment> Segments { get; internal set; }
		public Settings Settings { get; internal set; }
	}
}