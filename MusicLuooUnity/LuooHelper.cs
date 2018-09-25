using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicLuooUnity
{
    public class Common
    {
        public static string AssemblyPath = PubConstant.GetAppSetting("DAL");
        public static object CreateObjectNoCache(string classNamespace)
        {
            string className = classNamespace + AssemblyPath;
            try
            {
                object objType = Assembly.Load("MusicLuooUnity").CreateInstance(className);
                return objType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetSqlParam(object p)
        {
            if (p == null) return null;

            return p.ToString().Replace("'", "''");
        }
    }

    public class LuooVolHelper
    {
        static readonly ILuooVolHelper ObjType = new LuooVolHelperSql();
        public static void Add(LuooVolModel model)
        {
            ObjType.Add(model);
        }

        public static void AddList(List<LuooVolModel> models)
        {
            ObjType.AddList(models);
        }
        public static void Update(LuooVolModel model)
        {
            ObjType.Update(model);
        }
        public static void UpdateLocalPath(LuooVolModel model)
        {
            ObjType.UpdateLocalPath(model);
        }
        public static void Delete(int volNo)
        {
            ObjType.Delete(volNo);
        }
        public static List<LuooVolModel> GetAll()
        {
            return ObjType.GetAll();
        }
        public static List<LuooVolModel> UpdateCache()
        {
            return ObjType.UpdateCache();
        }
        public static LuooVolModel GetByVolNo(int no)
        {
            return ObjType.GetByVolNo(no);
        }

        public static List<LuooVolModel> GetListByLocalPath()
        {
            return ObjType.GetListByLocalPath();
        }
        public static List<string> GetVolKeywords()
        {
            var list = ObjType.GetVolKeywords();
            if (list == null) return null;
            List<string> datas = new List<string>();
            foreach (var l in list)
            {
                var arr = l.Split(',');
                foreach (var s in arr)
                {
                    if(datas.Contains(s)) continue;
                    datas.Add(s);
                }
            }
            return datas;
        }
    }

    public class LuooSongHelper
    {
        static readonly ILuooSongHelper ObjType = new LuooSongHelperSql();
        public static int GetAllCount()
        {
            return ObjType.GetAllCount();
        }
        public static void Add(LuooSongModel model)
        {
            ObjType.Add(model);
        }

        public static void AddList(List<LuooSongModel> models)
        {
            ObjType.AddList(models);
        }
        public static void Update(LuooSongModel model)
        {
            ObjType.Update(model);
        }
        public static void UpdateLocalPath(LuooSongModel model)
        {
            ObjType.UpdateLocalPath(model);
        }
        public static void Delete(Guid volNo)
        {
            ObjType.Delete(volNo);
        }
        public static List<LuooVolSongModel> GetAll()
        {
            return ObjType.GetAll();
        }
        public static List<LuooVolSongModel> UpdateCache(int top)
        {
            return ObjType.UpdateCache(top);
        }
        public static LuooSongModel GetByVolNo(Guid no)
        {
            return ObjType.GetByVolNo(no);
        }
        public static List<LuooSongModel> GetListByLocalPath()
        {
            return ObjType.GetListByLocalPath();
        }
        public static List<LuooVolSongModel> GetListPager(int pageIndex, int pageSize, string keywords)
        {
            return ObjType.GetListPager(pageIndex, pageSize, keywords);
        }
    }

    public class LuooTaskHelper
    {
        static readonly ILuooTaskHelper ObjType = new LuooTaskHelperSql();
        public static void Add(LuooTaskModel model)
        {
            ObjType.Add(model);
        }

        public static void Update(string id, int currCount)
        {
            ObjType.Update(id, currCount);
        }
        public static LuooTaskModel GetTaskById(string id)
        {
            return ObjType.GetTaskById(id);
        }
    }

    public class LuooCrawlersHelper
    {
        public int GetMaxVolNo()
        {
            try
            {
                HttpModel hm = new HttpModel();
                hm.ApplicationName = "music";
                hm.ContentType = "application/x-www-form-urlencoded";
                hm.Encode = Encoding.UTF8;
                hm.KeepAlive = false;
                hm.Method = "GET";
                hm.Url = "http://www.luoo.net/tag/?p=1";
                string err;
                HttpStatusCode hsc;
                string result = HttpHelper.HttpDo(hm, out err, out hsc);
                if (!string.IsNullOrEmpty(err))
                {
                    LoggerUtil.ErrorLog("LuooCrawlersHelper.GetMaxVolNo", new Exception(err));
                    return 0;
                }
                int startIndex = result.IndexOf("<div class=\"item\">") + 18;
                string temp = result.Substring(startIndex, 80);
                string vol = System.Text.RegularExpressions.Regex.Replace(temp, @"[^0-9]+", "");
                return int.Parse(vol);
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("LuooCrawlersHelper.GetMaxVolNo", ex);
                return 0;
            }
        }

        public void OpenVolPage(Guid taskId)
        {
            try
            {
                int onlineMaxVolNo = GetMaxVolNo();
                var oldVols = LuooVolHelper.GetAll();
                int localMaxVolNo = oldVols == null || oldVols.Count == 0 ? 0 : oldVols.Max(x => x.VolNo);
                if (onlineMaxVolNo <= localMaxVolNo)
                {
                    return;
                }
          
                const int perCount = 100;
                int count = (onlineMaxVolNo - localMaxVolNo) / perCount;
                if ((onlineMaxVolNo - localMaxVolNo) % perCount > 0) count += 1;

                LuooTaskModel task = new LuooTaskModel
                {
                    Id = taskId.ToString(),
                    AddTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    TotalTaskCount = count,
                    CurrentTaskCount = 0
                };
                LuooTaskHelper.Add(task);

                for (int i = 0; i < count; i++)
                {
                    int start = i * perCount + localMaxVolNo;
                    int end = start + perCount;
                    if (end > onlineMaxVolNo) end = onlineMaxVolNo;

                    OpenVolPageSync(start, end, task.Id);
                }
                
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("LuooCrawlersHelper.OpenVolPage", ex);
            }
        }

        public async void OpenVolPageSync(int start, int end, string taskId)
        {
            await Task.Run(() =>
            {
                List<LuooVolModel> volList = new List<LuooVolModel>();
                List<LuooSongModel> songList = new List<LuooSongModel>();

                for (int i = start + 1; i <= end; i++)
                {
                    var resp = OpenVolPageSingle(i);
                    if (resp != null)
                    {
                        volList.Add(resp.Item1);
                        songList.AddRange(resp.Item2);
                    }
                }

                ////期刊图片缓存
                //if (volList.Count > 0)
                //{
                //    foreach (var v in volList)
                //    {
                //        string name = GetFileNameFromUrl(v.VolPicUrl, 1).Replace("!","");
                //        string path = Consts.PictureLocalPath + name;
                //        v.VolPicLocalPath = path.Replace(Consts.PictureLocalPath, Consts.PictureFileUrl).Replace("\\","/");
                //        new WebClient().DownloadFileAsync(new Uri(v.VolPicUrl), path);
                //    }
                //}
                ////mp3缓存
                //if (songList.Count > 0)
                //{
                //    foreach (var v in songList)
                //    {
                //        string name = GetFileNameFromUrl(v.DownloadUrl, 2);
                //        string path = Consts.MusicLocalPath + v.VolNo + "\\";
                //        FileHelper.FolderCreate(path);
                //        path += name;
                //        v.LocalPath = path.Replace(Consts.MusicLocalPath, Consts.MusicLuooUrl).Replace("\\", "/");
                //        new WebClient().DownloadFileAsync(new Uri(v.DownloadUrl), path);
                //    }
                //}

                LuooVolHelper.AddList(volList);
                LuooSongHelper.AddList(songList);

                LuooTaskHelper.Update(taskId, 1);
            });
        }

        public Tuple<LuooVolModel, List<LuooSongModel>> OpenVolPageSingle(int volNo)
        {
            try
            {
                HttpModel hm = new HttpModel();
                hm.ApplicationName = "music";
                hm.ContentType = "application/x-www-form-urlencoded";
                hm.Encode = Encoding.UTF8;
                hm.KeepAlive = false;
                hm.Method = "GET";
                hm.Url = "http://www.luoo.net/vol/index/" + volNo;
                string err;
                HttpStatusCode hsc;
                string result = HttpHelper.HttpDo(hm, out err, out hsc);
                if (!string.IsNullOrEmpty(err))
                {
                    LoggerUtil.ErrorLog("LuooCrawlersHelper.OpenVolPageSingle", new Exception(err + "|" + hm.Url));
                    return OpenVolPageSingle(volNo);
                }
                //是否不存在
                if (result.Contains("404 - 找不到你访问的页面"))
                {
                    return null;
                }
                int startIndex = -1, endIndex = -1;
                string temp = "";

                #region 期刊

                LuooVolModel vol = new LuooVolModel();
                vol.VolNo = volNo;
                vol.VolUrl = hm.Url;
                vol.AddDate = DateTime.Now;

                #region 取期刊号/期刊名称

                startIndex = result.IndexOf("class=\"vol-number rounded\">");
                if (startIndex == -1)
                {
                    return null;
                }
                temp = result.Substring(startIndex + "class=\"vol-number rounded\">".Length, 20);
                vol.VolNumber = temp.Substring(0, temp.IndexOf("</span>"));
                startIndex = result.IndexOf("class=\"vol-title\">") + "class=\"vol-title\">".Length;
                temp = result.Substring(startIndex, 200);
                vol.VolName = temp.Substring(0, temp.IndexOf("</span>"));

                #endregion

                #region 取关键字
                string keyword = "";
                startIndex = 0;
                int countKey = System.Text.RegularExpressions.Regex.Matches(result, "class=\"vol-tag-item\">").Count;
                for (int i = 0; i < countKey; i++)
                {
                    startIndex = result.IndexOf("class=\"vol-tag-item\">", startIndex) + "class=\"vol-tag-item\">".Length;
                    string t = result.Substring(startIndex, 50);
                    if (t.Contains("</a>"))
                        keyword += t.Substring(0, t.IndexOf("</a>"));
                }

                vol.VolKeyword = keyword.Replace("#", ",").Trim(',').Trim();

                #endregion

                #region 取期刊图片

                startIndex = result.IndexOf("id=\"volCoverWrapper\"") + "id=\"volCoverWrapper\"".Length;
                temp = result.Substring(startIndex, 300);
                var arrs = temp.Split(' ');
                foreach (var a in arrs)
                {
                    if (a.Contains("src=\""))
                    {
                        vol.VolPicUrl = a.Replace("src=", "").Replace("\"", "");
                        break;
                    }
                }

                #endregion

                #endregion

                List<LuooSongModel> songs = new List<LuooSongModel>();
                #region 歌曲

                startIndex = 0;
                int count = System.Text.RegularExpressions.Regex.Matches(result, "class=\"trackname btn-play\">").Count;
                for (int i = 0; i < count; i++)
                {
                    startIndex = result.IndexOf("class=\"trackname btn-play\">", startIndex) + "class=\"trackname btn-play\">".Length;
                    string t = result.Substring(startIndex, 200);

                    LuooSongModel song = new LuooSongModel();
                    song.AddDate = DateTime.Now;
                    song.VolNo = volNo;
                    song.SongNo = Guid.NewGuid();
                    string songName = t.Substring(0, t.IndexOf("</a>"));
                    song.SongName = songName.Trim();
                    int index = i + 1;
                    string songId = index < 10 ? ("0" + index) : index.ToString();
                    song.DownloadUrl = "http://mp3-cdn2.luoo.net/low/luoo/radio" + vol.VolNumber.TrimStart('0') + "/" + songId + ".mp3";
                    songs.Add(song);
                }

                startIndex = 0;
                count = System.Text.RegularExpressions.Regex.Matches(result, "<p class=\"artist\">").Count;
                for (int i = 0; i < count; i++)
                {
                    startIndex = result.IndexOf("<p class=\"artist\">", startIndex) + "<p class=\"artist\">".Length;
                    string t = result.Substring(startIndex, 200);
                    t = t.Substring(0, t.IndexOf("</p>"));
                    songs[i].Author = t.Replace("Artist:", "").Trim();
                }

                startIndex = 0;
                count = System.Text.RegularExpressions.Regex.Matches(result, "<p class=\"album\">").Count;
                for (int i = 0; i < count; i++)
                {
                    startIndex = result.IndexOf("<p class=\"album\">", startIndex) + "<p class=\"album\">".Length;
                    string t = result.Substring(startIndex, 300);
                    t = t.Substring(0, t.IndexOf("</p>"));
                    songs[i].AlbumName = t.Replace("Album:", "").Trim();
                }
                
                #endregion

                Tuple<LuooVolModel, List<LuooSongModel>> response = new Tuple<LuooVolModel, List<LuooSongModel>>(vol, songs);

                return response;
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("OpenVolPageSingle:" + volNo, ex);
                return null;
            }
        }
    }


}
