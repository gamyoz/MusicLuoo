using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLuooUnity
{
    public class HttpModel
    {
        public string ApplicationName { get; set; } = "TuanDai.HttpClient";
        public string Url { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; } = "application/json";
        public string Param { get; set; }
        public Dictionary<string, string> Header { get; set; }
        public int TimeOut { get; set; } = 10;
        public Encoding Encode { get; set; } = Encoding.UTF8;
        public bool KeepAlive { get; set; } = true;
        public bool IsTraceLog { get; set; } = true;
    }

    #region 实体

    public class LuooVolModel
    {
        /// <summary>
        /// 期刊编号
        /// </summary>
        public int VolNo { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string VolKeyword { get; set; }
        /// <summary>
        /// 期刊链接
        /// </summary>
        public string VolUrl { get; set; }
        /// <summary>
        /// 期刊图片
        /// </summary>
        public string VolPicUrl { get; set; }
        /// <summary>
        /// 期刊名称
        /// </summary>
        public string VolName { get; set; }
        public string VolNumber { get; set; }
        public DateTime AddDate { get; set; }
        public string VolPicLocalPath { get; set; }
    }

    public class LuooVolSongModel: LuooSongModel
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string VolKeyword { get; set; }
        /// <summary>
        /// 期刊链接
        /// </summary>
        public string VolUrl { get; set; }
        /// <summary>
        /// 期刊图片
        /// </summary>
        public string VolPicUrl { get; set; }
        /// <summary>
        /// 期刊名称
        /// </summary>
        public string VolName { get; set; }
        public string VolNumber { get; set; }
        public string VolPicLocalPath { get; set; }
    }

    public class LuooSongModel
    {
        public Guid SongNo { get; set; }
        public int VolNo { get; set; }
        public string DownloadUrl { get; set; }
        /// <summary>
        /// 歌曲名
        /// </summary>
        public string SongName { get; set; }
        /// <summary>
        /// 专辑名
        /// </summary>
        public string AlbumName { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        public DateTime AddDate { get; set; }
        public string LocalPath { get; set; }
        public int SongIndex { get; set; }
    }

    public class LuooTaskModel
    {
        public string Id { get; set; }
        public int TotalTaskCount { get; set; }
        public int CurrentTaskCount { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    #endregion

}
