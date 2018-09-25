using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MusicLuooUnity;
using Newtonsoft.Json;

namespace MusicLuoo
{
    public partial class FormMusicOther : Form
    {
        public FormMusicOther()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            if (string.IsNullOrEmpty(key)) return;

            HttpModel hm = new HttpModel();
            hm.ApplicationName = "music";
            hm.ContentType = "application/x-www-form-urlencoded";
            hm.Encode = Encoding.UTF8;
            hm.KeepAlive = false;
            hm.Method = "GET";
            hm.Url = "http://tingapi.ting.baidu.com/v1/restserver/ting?method=baidu.ting.search.catalogSug&&query=" +
                     key;
            string err;
            HttpStatusCode hsc;
            string result = HttpHelper.HttpDo(hm, out err, out hsc);
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err);
                return;
            }

            var resp = JsonConvert.DeserializeObject<QueryResponseModel>(result);
            if (resp.song == null || resp.song.Count == 0)
            {
                MessageBox.Show("没有找到歌曲信息");
                return;
            }

            List<SongShowModel> models = new List<SongShowModel>();
            foreach (var s in resp.song)
            {
                hm.KeepAlive = true;
                hm.Url = "http://tingapi.ting.baidu.com/v1/restserver/ting?method=baidu.ting.song.play&songid=" + s.songid;

                string r = HttpHelper.HttpDo(hm, out err, out hsc);
                if (string.IsNullOrEmpty(err))
                {
                    var m = JsonConvert.DeserializeObject<SongDetailModel>(r);
                    models.Add(new SongShowModel
                    {
                        song_id = m.songinfo.song_id,
                        album_title = m.songinfo.album_title,
                        author = m.songinfo.author,
                        file_extension = m.bitrate.file_extension,
                        file_link = m.bitrate.file_link,
                        file_size = Math.Round(decimal.Parse(m.bitrate.file_size) / 1024 / 1024,1)+"M",
                        lrclink = m.songinfo.lrclink,
                        pic_big = m.songinfo.pic_big,
                        pic_small = m.songinfo.pic_small,
                        si_proxycompany = m.songinfo.si_proxycompany,
                        title = m.songinfo.title,
                        
                    });
                }
            }

            dgvData.DataSource = models;
        }

        /// <summary>
        /// 处理dataGridView1的RowsAdded事件，在每行被载入后，即开始异步获取图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ////利用 WebClient 来下载图片
            using (WebClient wc = new WebClient())
            {
                ////WebClient 下载完毕的响应事件绑定
                wc.DownloadDataCompleted += new DownloadDataCompletedEventHandler(wc_DownloadDataCompleted);

                

                ////开始异步下载，图片URL路径请根据实际情况自己去指定
                ////同时将DataGridView当前行的行号传递过去，用于指定图片显示的CELL
                wc.DownloadDataAsync(new Uri(dgvData.Rows[e.RowIndex].Cells["pic_small"].Value.ToString()),
                    e.RowIndex);
            }
        }

        /// <summary>
        /// 图片下载完毕，显示于对应的CELL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            ////如果下载过程未发生错误，并且未被中途取消
            if (e.Error == null && !e.Cancelled)
            {
                ////将图片显示于对应的指定单元格， e.UserState 就是传入的 e.RowIndex
                ////e.Result 就是下载结果
                this.dgvData.Rows[(int)e.UserState].Cells["PictureColumn"].Value = e.Result;
            }
        }

        #region MyRegion
        private class QueryResponseModel
        {
            public List<QueryResponseSongModel> song { get; set; }
            public int error_code { get; set; }
            public string order { get; set; }
        }

        private class QueryResponseSongModel
        {
            public string bitrate_fee { get; set; }
            public string weight { get; set; }
            public string songname { get; set; }
            public string resource_type { get; set; }
            public string songid { get; set; }
            public string has_mv { get; set; }
            public string yyr_artist { get; set; }
            public string resource_type_ext { get; set; }
            public string artistname { get; set; }
            public string info { get; set; }
            public string resource_provider { get; set; }
            public string control { get; set; }
            public string encrypted_songid { get; set; }
        }

        private class SongDetailModel
        {
            public SongDetailSonginfoModel songinfo { get; set; }
            public string error_code { get; set; }
            public SongDetailBitrateModel bitrate { get; set; }
        }
        private class SongDetailSonginfoModel
        {
            public string song_id { get; set; }
            public string pic_big { get; set; }
            public string si_proxycompany { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string album_title { get; set; }
            public string pic_small { get; set; }
            public string lrclink { get; set; }
        }
        private class SongDetailBitrateModel
        {
            public string show_link { get; set; }
            public string free { get; set; }
            public string song_file_id { get; set; }
            public string file_size { get; set; }
            public string file_extension { get; set; }
            public string file_duration { get; set; }
            public string file_bitrate { get; set; }
            public string file_link { get; set; }
            public string hash { get; set; }
        }

        private class SongShowModel
        {
            public string song_id { get; set; }
            public string pic_big { get; set; }
            public string si_proxycompany { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string album_title { get; set; }
            public string pic_small { get; set; }
            public string lrclink { get; set; }
            public string file_link { get; set; }
            public string file_size { get; set; }
            public string file_extension { get; set; }

        }


        #endregion

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var sels = dgvData.SelectedRows;
            if (sels.Count  == 0)
            return;

            string path = AppDomain.CurrentDomain.BaseDirectory+ txtKey.Text.Trim()+"\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (DataGridViewRow sel in sels)
            {
                string link = sel.Cells["file_link"].Value.ToString();
                if (string.IsNullOrEmpty(sel.Cells["file_link"].Value.ToString())) continue;

                string name = sel.Cells["song_id"].Value + "." + sel.Cells["file_extension"].Value;
                DownFile(link, path, name);
            }
        }

        private void DownFile(string uRLAddress, string localPath, string filename)
        {
            WebClient client = new WebClient();
            Stream str = client.OpenRead(uRLAddress);
            StreamReader reader = new StreamReader(str);
            byte[] mbyte = new byte[1000000];
            int allmybyte = (int)mbyte.Length;
            int startmbyte = 0;

            while (allmybyte > 0)
            {

                int m = str.Read(mbyte, startmbyte, allmybyte);
                if (m == 0)
                {
                    break;
                }
                startmbyte += m;
                allmybyte -= m;
            }

            reader.Dispose();
            str.Dispose();

            //string paths = localPath + System.IO.Path.GetFileName(uRLAddress);
            string path = localPath + filename;
            FileStream fstr = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            fstr.Write(mbyte, 0, startmbyte);
            fstr.Flush();
            fstr.Close();
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            var sels = dgvData.SelectedRows.Count;
            btnDownload.Text = "下载[" + sels + "]";
        }

        private void FormMusicOther_Load(object sender, EventArgs e)
        {
            string o = "12.77";
            var d=double.Parse(decimal.Parse(o.ToString()).ToString()).ToString();
            MessageBox.Show(d.ToString());
        }
    }
}
