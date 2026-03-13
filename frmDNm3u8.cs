using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmDNm3u8 : Form
    {
        public frmDNm3u8()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtURL.Text))
                return;

            string referer = string.Empty;
            if (!string.IsNullOrEmpty(txtReferer.Text))
            {
                referer = string.Format(" -referer \"{0}\" ", txtReferer.Text);
            }

            string template = ffmpeg_mini_gui.Properties.Resources.download_m3u8;

            template = template.Replace("{ffmpeg}", General.appStartPath + "\\ffmpeg.exe")
                            .Replace("{refer}", referer)
                            .Replace("{url}", txtURL.Text).Replace("{output}", General.appStartPath + "\\" + General.GetNow());

            string batchFilePath = Path.GetTempFileName() + ".bat";

            File.WriteAllText(batchFilePath, template);

            await General.ExecuteBatchFile(batchFilePath);

        }

        private void btnPasteURL_Click(object sender, EventArgs e)
        {
            txtURL.Text = General.GetFromClipboard();
        }

        private void btnRefererURL_Click(object sender, EventArgs e)
        {
            txtReferer.Text = General.GetFromClipboard();
        }
    }
}
