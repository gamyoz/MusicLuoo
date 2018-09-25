using System;
using System.IO;
using System.Windows.Forms;

namespace MusicLuoo
{
    public partial class FormMusic : Form
    {
        public FormMusic()
        {
            InitializeComponent();
        }

        #region 落网
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = webBrow.DocumentText;
            if (string.IsNullOrEmpty(txt)) return;

            //获取专辑号
            string volNumber = GetVolNumber();
            if (string.IsNullOrEmpty(volNumber))
            {
                MessageBox.Show("错误：获取专辑号失败");
                return;
            }

            string song = ddlSongNo.SelectedItem.ToString();
            string songNumber = song.Substring(0, song.IndexOf('.'));

            label1.Text = string.Empty;


            string url = "http://mp3-cdn2.luoo.net/low/luoo/radio" + volNumber + "/" + songNumber + ".mp3";
            string path = AppDomain.CurrentDomain.BaseDirectory + volNumber + "\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DownloadFile(url, path + song.Substring(song.IndexOf('.') + 1).Trim() + ".mp3");
            label1.Text += "下载[" + song + "]已完成.";
            System.Diagnostics.Process.Start(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrow.Navigate(txtUrl.Text);
        }

        private void GetSongName()
        {
            var list = webBrow.Document.GetElementsByTagName("a");
            ddlSongNo.Items.Clear();
            foreach (WebKit.DOM.Element l in list)
            {
                if (l.HasAttribute("class") && l.Attributes["class"].NodeValue == "trackname btn-play")
                {
                    ddlSongNo.Items.Add(l.TextContent);
                }
            }
            ddlSongNo.SelectedIndex = 0;
        }

        private string GetVolNumber()
        {
            var list = webBrow.Document.GetElementsByTagName("span");

            string volNumber = string.Empty;
            foreach (WebKit.DOM.Element l in list)
            {
                if (l.HasAttribute("class") && l.Attributes["class"].NodeValue == "vol-number rounded")
                {
                    volNumber = l.TextContent.TrimStart('0');
                    break;
                }
            }
            return volNumber;
        }

        #endregion


        private void webBrow_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void webBrow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrow.Url == null) return;
            string txt = webBrow.DocumentText;
            if (string.IsNullOrEmpty(txt)) return;

            //获取歌曲名字
            GetSongName();
        }

        /// <summary>
        /// 保存远程文件到本地
        /// </summary>
        /// <param name="url">远程文件URL</param>
        /// <param name="file">保存的本地路径</param>
        /// <returns></returns>
         void DownloadFile(string url, string file)
        {
            try
            {
                (new System.Net.WebClient()).DownloadFile(url, file);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            //webBrow.Navigate(txtUrl.Text);
        }

        private void FormMusic_Load(object sender, EventArgs e)
        {

        }
    }
}
