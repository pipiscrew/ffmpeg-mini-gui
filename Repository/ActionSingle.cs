using System.IO;
using System.Windows.Forms;

namespace ffmpeg_mini_gui.Repository
{
    internal class ActionSingle : IAction
    {
        public void Validate(ConversionProperties props)
        {
            if (!File.Exists(props.videoTXT))
            {
                General.Mes("Video file doesnt exist.", MessageBoxIcon.Exclamation);
                return;
            }
            else if (File.Exists(props.subTXT))
            {
                if (!General.IsFileUtf8(General.GetSubtitleFilePathByVideo(props.videoTXT)))
                {
                    General.Mes("Subtitle file is not UTF8 (required by ffmpeg).", MessageBoxIcon.Error);
                    return;
                }
            }
            else if (props.subTXT.Length > 0 && !File.Exists(props.subTXT))
            {
                General.Mes("Subtitle file doesnt exist.", MessageBoxIcon.Exclamation);
                return;
            }

            string outputFilename;
            if (File.Exists(props.subTXT))
                outputFilename = General.GetOutputFilenameForHardSubbed(props.videoTXT);
            else
                outputFilename = General.GetOutputFilename(props.videoTXT);

            string template;
            if (props.twoPass)
                template = ffmpeg_mini_gui.Properties.Resources.twopassCMD;
            else
                template = ffmpeg_mini_gui.Properties.Resources.onepassCMD;

            string subtitleFix = General.GetSubtitlePath(props.subTXT);
            string filters = General.ConstructFinalFilters(subtitleFix, props.scaleFix, props.fpsFix);
            props.files.Add(
                new FileProperties()
                {
                    file = props.videoTXT,
                    subtitleFix = subtitleFix,
                    filters = filters,
                    batchFilepath = Path.GetTempFileName() + ".bat",
                    outputFilename = outputFilename,
                    template = template.Replace("*video*", props.videoTXT).Replace("*bitrate*", props.bitrate).Replace("*preset*", props.preset)
                        .Replace("*output*", outputFilename).Replace("*curr*", General.appStartPath).Replace("*filters*", filters) //props.files[0].filters
                        .Replace("%timecut%", props.timeCut)
                }
           );
         

            //props.template = props.template.Replace("*video*", props.videoTXT).Replace("*bitrate*", props.bitrate).Replace("*preset*", props.preset)
            //            .Replace("*output*", props.outputFilename).Replace("*curr*", General.appStartPath).Replace("*filters*", props.files[0].filters)
            //            .Replace("%timecut%", props.timeCut);
        }
    }
}
