using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * source by - https://github.com/AlexPoint/SubtitlesParser
 */
namespace ffmpeg_mini_gui
{
    public class SrtWriter
    {
        private string formatTimecodeLine(SubtitleItem subtitleItem)
        {
            TimeSpan start = TimeSpan.FromMilliseconds(subtitleItem.StartTime);
            TimeSpan end = TimeSpan.FromMilliseconds(subtitleItem.EndTime);
            return string.Format("{0:00}:{1:00}:{2:00},{3:000} --> {4:00}:{5:00}:{6:00},{7:000}",
                                 start.Hours, start.Minutes, start.Seconds, start.Milliseconds,
                                 end.Hours, end.Minutes, end.Seconds, end.Milliseconds);
        }

        private IEnumerable<string> SubtitleItemToSubtitleEntry(SubtitleItem subtitleItem, int subtitleEntryNumber, bool includeFormatting)
        {
            List<string> lines = new List<string>
            {
                subtitleEntryNumber.ToString(),
                formatTimecodeLine(subtitleItem)
            };

            if (!includeFormatting && subtitleItem.PlaintextLines != null)
                lines.AddRange(subtitleItem.PlaintextLines);
            else
                lines.AddRange(subtitleItem.Lines);

            return lines;
        }

        public void WriteStream(Stream stream, IEnumerable<SubtitleItem> subtitleItems, bool includeFormatting)
        {
            using (TextWriter writer = new StreamWriter(stream))
            {
                List<SubtitleItem> items = subtitleItems.ToList(); // avoid multiple enumeration
                for (int i = 0; i < items.Count; i++)
                {
                    SubtitleItem subtitleItem = items[i];
                    IEnumerable<string> lines = SubtitleItemToSubtitleEntry(subtitleItem, i + 1, includeFormatting); 
                    foreach (string line in lines)
                        writer.WriteLine(line);

                    writer.WriteLine(); // empty line between subtitle entries
                }
            }
        }
    }
}
