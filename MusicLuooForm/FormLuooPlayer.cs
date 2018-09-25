using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MusicLuooUnity;
using MusicLuooUnity.BLL;
using WMPLib;

namespace MusicLuoo
{
    public partial class FormLuooPlayer : Form
    {
        public FormLuooPlayer()
        {
            InitializeComponent();
        }

        private void FormLuooPlayer_Load(object sender, EventArgs e)
        {
            listSong.GridLines = true;
            listSong.View = View.Details;
            listSong.Scrollable = true;
            listSong.HeaderStyle = ColumnHeaderStyle.Clickable;
            listSong.FullRowSelect = true;

            //添加表头
            listSong.Columns.Add("Name", 300);
            listSong.Columns.Add("Album", 300);
            listSong.Columns.Add("Artist", 200);
           
            DataLoad();
        }

        private void DataLoad()
        {
            try
            {
                //var vols = LuooVolHelper.GetAll();
                var songs = LuooSongHelper.GetAll();
                if (songs == null) return;

                axWmp.currentPlaylist.clear();
                foreach (var s in songs)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = s.SongName;
                    lvi.ForeColor = Color.Black;
                    lvi.SubItems.Add(s.AlbumName);
                    lvi.SubItems.Add(s.Author);
                    lvi.Tag = s.DownloadUrl;
                    this.listSong.Items.Add(lvi);

                    if (!string.IsNullOrEmpty(s.DownloadUrl))
                    {
                        IWMPMedia a = axWmp.newMedia(s.DownloadUrl);
                        axWmp.currentPlaylist.appendItem(a);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("FormLuooPlayer.DataLoad", ex);
            }
        }

        private void 重新加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDataFromLuoo();
        }

        private void listSong_DoubleClick(object sender, EventArgs e)
        {
            if (listSong.SelectedItems.Count == 0)
                return;
            ListViewItem currentRow = listSong.SelectedItems[0];

            toolsslTip.ForeColor = Color.Gray;
            toolsslTip.Text = "[正在播放]" + currentRow.Text;

            int index = 0;
            foreach (ListViewItem v in listSong.Items)
            {
                if (v.Selected)
                {
                    break;
                }
                index++;
            }

            axWmp.currentMedia = axWmp.currentPlaylist.Item[index];
            //axWmp.URL = currentRow.Tag.ToString();
            //axWmp.Ctlcontrols.play();
        }

        private void GetDataFromLuoo()
        {
            listSong.Items.Clear();

            TaskId = Guid.NewGuid();

            toolsslTip.ForeColor = Color.Gray;
            toolsslTip.Text = "正在从服务器获取数据，请耐心等待......";
            Application.DoEvents();
            new LuooCrawlersHelper().OpenVolPage(TaskId);

            timer.Enabled = true;
        }

        private void 全部重新加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolsslTip.ForeColor = Color.Gray;
            toolsslTip.Text = "正在清除所有历史数据，请耐心等待......";
            Application.DoEvents();
            LuooVolHelper.Delete(0);
            LuooSongHelper.Delete(Guid.Empty);

            GetDataFromLuoo();
        }

        private Guid TaskId;
        private void timer_Tick(object sender, EventArgs e)
        {
            var model = LuooTaskHelper.GetTaskById(TaskId.ToString());
            if (model == null)
            {
                //timer.Enabled = false;
                //toolsslTip.ForeColor = Color.Red;
                //toolsslTip.Text = "获取任务数据失败！请检查！";
                //Application.DoEvents();
                return;
            }

            if (model.TotalTaskCount <= model.CurrentTaskCount)
            {
                timer.Enabled = false;
                toolsslTip.ForeColor = Color.Green;
                toolsslTip.Text = "从服务器更新数据成功完成！";

                LuooVolHelper.UpdateCache();
                LuooSongHelper.UpdateCache(0);

                DataLoad();
                Application.DoEvents();
                return;
            }

            toolsslTip.ForeColor = Color.Gray;
            toolsslTip.Text = string.Format("正在获取数据 {0}/{1}", model.CurrentTaskCount, model.TotalTaskCount);
            Application.DoEvents();
        }

        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWmp.Ctlcontrols.play();
        }

        private void 下一首ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = axWmp.currentPlaylist;
            if (list != null && list.count > 1)
            {
                axWmp.Ctlcontrols.next();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void axWmp_CurrentItemChange(object sender, AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent e)
        {
            toolsslTip.ForeColor = Color.Gray;

            int index = 0;
            foreach (ListViewItem v in listSong.Items)
            {
                if (v.Tag.ToString() == axWmp.currentMedia.sourceURL)
                {
                    v.ForeColor = Color.White;
                    v.BackColor = Color.Blue;
                    v.Selected = true;
                    toolsslTip.Text = "[正在播放]" + v.SubItems[0].Text;
                    break;
                }
                index++;
            }
            if (index > 0)
            {
                listSong.Items[index - 1].ForeColor = Color.Black;
                listSong.Items[index - 1].BackColor = Color.White;
            }
            Application.DoEvents();
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem currentRow = listSong.SelectedItems[0];
            string url = currentRow.Tag.ToString();

            try
            {
                string path = Application.StartupPath + "/download/";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string file = path + currentRow.SubItems[0].Text + ".mp3";
                (new System.Net.WebClient()).DownloadFile(url, file);
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void timerCache_Tick(object sender, EventArgs e)
        {
            //vol
            var vols = LuooVolHelper.GetListByLocalPath();
            if (vols != null && vols.Count > 0)
            {
                foreach (var v in vols)
                {
                    string name = GetFileNameFromUrl(v.VolPicUrl, 1).Replace("!", "");
                    string path = Consts.PictureLocalPath + name;
                    v.VolPicLocalPath = path.Replace(Consts.PictureLocalPath, Consts.PictureFileUrl).Replace("\\", "/");
                    if (!File.Exists(path))
                    {
                        new WebClient().DownloadFileAsync(new Uri(v.VolPicUrl), path);
                    }
                    LuooVolHelper.UpdateLocalPath(v);
                }
            }

            //song
            var songs = LuooSongHelper.GetListByLocalPath();
            if (songs != null && songs.Count > 0)
            {
                foreach (var v in songs)
                {
                    string name = GetFileNameFromUrl(v.DownloadUrl, 2);
                    string path = Consts.MusicLocalPath + v.VolNo + "\\";
                    FileHelper.FolderCreate(path);
                    path += name;
                    v.LocalPath = path.Replace(Consts.MusicLocalPath, Consts.MusicFileUrl).Replace("\\", "/");
                    if (!File.Exists(path))
                    {
                        new WebClient().DownloadFileAsync(new Uri(v.DownloadUrl), path);
                    }
                    LuooSongHelper.UpdateLocalPath(v);
                }
            }

            if (vols != null && vols.Count == 0 && songs != null && songs.Count == 0)
            {
                timerCache.Enabled = false;
            }
        }


        private string GetFileNameFromUrl(string url, int type)
        {
            if (string.IsNullOrEmpty(url)) return "";
            var arrs = url.Split('/');
            if (type == 1)
                return arrs.FirstOrDefault(x => x.ToLower().Contains(".jpg") || x.ToLower().Contains(".png") || x.ToLower().Contains(".gif") || x.ToLower().Contains(".jpeg"));
            return arrs.FirstOrDefault(x => x.ToLower().Contains(".mp3") || x.ToLower().Contains(".wav"));
        }

    }
}
