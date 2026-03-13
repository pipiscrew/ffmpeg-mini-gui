using System.Collections.Generic;

namespace ffmpeg_mini_gui.Repository
{
    internal class ConversionProperties
    {
        //[1]
        public string videoTXT { get; set; }
        public string subTXT { get; set; }
        public string videoFolder { get; set; }

        //[2]
        public string bitrate { get; set; }
        public string timeCut { get; set; }
        public string scaleFix { get; set; }
        public string fpsFix { get; set; }
        public string preset { get; set; }
        public bool twoPass { get; set; }

        //[3]
        public List<FileProperties> files { get; set; }

        internal ConversionProperties()
        {
            files = new List<FileProperties>();
        }
    }

    internal class FileProperties
    {
        public string file { get; set; }
        public string subtitleFix { get; set; }
        public string filters { get; set; }
        public string template { get; set; }
        public string outputFilename { get; set; }
        public string batchFilepath { get; set; }
    }
}
