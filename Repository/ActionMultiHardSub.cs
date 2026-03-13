using System.IO;
using System.Windows.Forms;

namespace ffmpeg_mini_gui.Repository
{
    internal class ActionMultiHardSub : IAction
    {
        public void Validate(ConversionProperties props)
        {
            string[] multiFiles = props.videoTXT.Split(new char[] { '*' });

            if (!ValidateMultiFiles(multiFiles))
            {
                return;
            }

            string template;

            if (props.twoPass)
                template = ffmpeg_mini_gui.Properties.Resources.twopassCMD;
            else
                template = ffmpeg_mini_gui.Properties.Resources.onepassCMD;

            foreach (string file in multiFiles)
            {
                string outputFilename = General.GetOutputFilenameForHardSubbed(file);
                string subtitleFix = General.GetSubtitlePath(General.GetSubtitleFilePathByVideo(file));
                string filters = General.ConstructFinalFilters(subtitleFix, props.scaleFix, props.fpsFix);
                props.files.Add(
                    new FileProperties()
                    {
                        file = file,
                        subtitleFix = subtitleFix,
                        filters = filters,
                        batchFilepath = Path.GetTempFileName() + ".bat",
                        outputFilename = outputFilename,
                        template = template.Replace("*video*", file).Replace("*bitrate*", props.bitrate).Replace("*preset*", props.preset)
                            .Replace("*output*", outputFilename).Replace("*curr*", General.appStartPath).Replace("*filters*", filters) 
                            .Replace("%timecut%", props.timeCut)
                    }
               );
            }
        }


        private static bool ValidateMultiFiles(string[] multiFiles)
        {
            string invalid = string.Empty;
            string invalidSubs = string.Empty;
            foreach (string file in multiFiles)
            {
                if (!File.Exists(file) || !File.Exists(General.GetSubtitleFilePathByVideo(file)))
                {
                    invalid += file + "\r\n";
                }
                else
                {
                    if (!General.IsFileUtf8(General.GetSubtitleFilePathByVideo(file)))
                    {
                        invalidSubs += file + "\r\n";
                    }
                }
            }

            if (invalidSubs != string.Empty)
            {
                General.Mes("Subtitle file is not UTF8 (required by ffmpeg) for the videos :\r\n\r\n" + invalidSubs, MessageBoxIcon.Error);
                return false;
            }
            else if (invalid != string.Empty)
            {
                General.Mes("Video file not found or video subtitle not found for the following :\r\n\r\n" + invalid, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
    }
}
