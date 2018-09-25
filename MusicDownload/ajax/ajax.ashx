<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

public class ajax : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string action = context.Request["action"];
        ResponseModel resp = new ResponseModel ();
        try
        {
            switch (action)
            {
                case "Query":
                    string err;
                    var list = Query(context, out err);
                    if (!string.IsNullOrEmpty(err))
                    {
                        resp.code = -1;
                        resp.message = err;
                    }
                    else
                    {
                        resp.data = list;
                        resp.code = 1;
                    }
                    break;
                default:
                    resp.code = -1;
                    resp.message = "系统参数错误,未找到对应方法";
                    break;
            }
        }
        catch (Exception ex)
        {
            resp.code = -1;
            resp.message = ex.Message;
        }

        context.Response.Write(JsonConvert.SerializeObject(resp));
    }

    #region 查询

    private List<SongShowModel> Query(HttpContext context, out string err)
    {
        string key = context.Request["key"];
        HttpModel hm = new HttpModel();
        hm.ApplicationName = "music";
        hm.ContentType = "application/x-www-form-urlencoded";
        hm.Encode = Encoding.UTF8;
        hm.KeepAlive = false;
        hm.Method = "GET";
        hm.TimeOut = 3;
        hm.Url = "http://tingapi.ting.baidu.com/v1/restserver/ting?method=baidu.ting.search.catalogSug&&query=" + key;
        HttpStatusCode hsc;
        string result = HttpHelper.HttpDo(hm, out err, out hsc);
        if (!string.IsNullOrEmpty(err))
        {
            return null;
        }

        var resp = JsonConvert.DeserializeObject<QueryResponseModel>(result);
        if (resp.song == null || resp.song.Count == 0)
        {
            err = "没有找到歌曲信息";
            return null;
        }

        string path = AppDomain.CurrentDomain.BaseDirectory + "music\\" + key + "\\";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);


        List<SongShowModel> models = new List<SongShowModel>();
        foreach (var s in resp.song)
        {
            hm.KeepAlive = true;
            hm.Url = "http://tingapi.ting.baidu.com/v1/restserver/ting?method=baidu.ting.song.play&songid=" + s.songid;

            string r = HttpHelper.HttpDo(hm, out err, out hsc);
            if (string.IsNullOrEmpty(err))
            {
                var m = JsonConvert.DeserializeObject<SongDetailModel>(r);
                string name = m.songinfo.title + "("+ m.songinfo.author + ")" + "." + m.bitrate.file_extension;
                models.Add(new SongShowModel
                {
                    song_id = m.songinfo.song_id,
                    album_title = m.songinfo.album_title,
                    author = m.songinfo.author,
                    file_extension = m.bitrate.file_extension,
                    file_link = m.bitrate.file_link,
                    file_size = Math.Round(decimal.Parse(m.bitrate.file_size) / 1024 / 1024, 1) + "M",
                    lrclink = m.songinfo.lrclink,
                    pic_big = m.songinfo.pic_big,
                    pic_small = m.songinfo.pic_small,
                    si_proxycompany = m.songinfo.si_proxycompany,
                    title = m.songinfo.title,
                    file_localpath = "/music/" + key + "/"+ name
                });
            }
        }

        Action action = () =>
        {
            foreach (var m in models)
            {
                if (string.IsNullOrEmpty(m.file_link)) return;
                string name = m.file_localpath.Substring(m.file_localpath.LastIndexOf("/") + 1);
                DownFile(m.file_link, path, name);
            }
        };
        action.BeginInvoke(null, null);

        err = string.Empty;
        return models;
    }

    #endregion

    #region 下载

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

    #endregion

    public bool IsReusable {
        get {
            return false;
        }
    }

    #region 实体

    private class ResponseModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }

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
        public string file_localpath { get; set; }
    }


    #endregion

}