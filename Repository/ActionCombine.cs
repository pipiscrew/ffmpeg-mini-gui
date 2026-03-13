
using System.IO;
namespace ffmpeg_mini_gui.Repository
{
    internal class ActionCombine : IAction
    {
        public void Validate(ConversionProperties props)
        {
            string combineVideoFolder = props.videoFolder;
            string videoOutput = string.Empty;

            if (!CheckFilesForCombine(combineVideoFolder, props.videoTXT))
                return;
            else
                props.videoTXT = "concat:" + props.videoTXT;

            string subtitleFix = General.GetSubtitlePath(props.subTXT);
            string filters = General.ConstructFinalFilters(subtitleFix, props.scaleFix, props.fpsFix);
            string outputFilename = GetOutputFilenameForCombine(combineVideoFolder, props.videoTXT);
            string template;

            if (props.twoPass)
                template = ffmpeg_mini_gui.Properties.Resources.twopassCMD;
            else
                template = ffmpeg_mini_gui.Properties.Resources.onepassCMD;

            props.files.Add(
                new FileProperties()
                {
                    file = props.videoTXT,
                    subtitleFix = subtitleFix,
                    filters = filters,
                    batchFilepath = string.Format("{0}action{1}.bat", combineVideoFolder, General.GetNow()),
                    outputFilename = GetOutputFilenameForCombine(combineVideoFolder, props.videoTXT),
                    template = template.Replace("*video*", props.videoTXT).Replace("*bitrate*", props.bitrate).Replace("*preset*", props.preset)
                        .Replace("*output*", outputFilename).Replace("*curr*", General.appStartPath).Replace("*filters*", filters) //props.files[0].filters
                        .Replace("%timecut%", props.timeCut)
                }
           );
        }

        private static bool CheckFilesForCombine(string videoFolder, string videoFilenames)
        {
            string[] files = videoFilenames.Split(new char[] { '|' });

            foreach (string f in files)
            {
                if (!File.Exists(videoFolder + f))
                {
                    General.Mes("Video file doesnt exist :\r\n\r\n" + f);
                    return false;
                }
            }

            return true;
        }

        private static string GetOutputFilenameForCombine(string videoFolder, string sourceVideoFilePath)
        {
            sourceVideoFilePath = sourceVideoFilePath.Split(new char[] { '|' })[0].Replace("concat:", "");
            return string.Format("{0}{1}_{2}-output.mp4", videoFolder, Path.GetFileNameWithoutExtension(sourceVideoFilePath), General.GetNow());
        }
    }
}
