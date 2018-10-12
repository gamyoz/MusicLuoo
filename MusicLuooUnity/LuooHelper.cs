using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MusicLuooUnity.BLL;

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

    public class LuooCrawlersHelper
    {
        private readonly HtmlWeb _web = new HtmlWeb();

        public int GetMaxVolNo()
        {
            try
            {
                var doc = _web.Load("http://www.luoo.net/tag/?p=1");
                var list =
                    doc.DocumentNode.SelectNodes("//a").Where(x => x.GetAttributeValue("class", "") == "cover-wrapper");

                if (list.Any())
                {
                    return list.Max(x => int.Parse(x.Attributes["href"].Value.Split('/').Last()));
                }
                //
                return 0;
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
                int localMaxVolNo = BLL.LuooVolHelper.GetMaxVolNo();
                if (onlineMaxVolNo <= localMaxVolNo)
                {
                    return;
                }

                const int perCount = 100;
                int count = (onlineMaxVolNo - localMaxVolNo)/perCount;
                if ((onlineMaxVolNo - localMaxVolNo)%perCount > 0) count += 1;

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
                    int start = i*perCount + localMaxVolNo;
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
                string volUrl = "http://www.luoo.net/vol/index/" + volNo;
                var doc = _web.Load(volUrl);
                var node = doc.DocumentNode;
                //是否不存在
                if (doc.ToString().Contains("404 - 找不到你访问的页面"))
                {
                    return null;
                }

                #region 期刊

                LuooVolModel vol = new LuooVolModel();
                vol.VolNo = volNo;
                vol.VolUrl = volUrl;
                vol.AddDate = DateTime.Now;

                #region 取期刊号/期刊名称

                var h1 = node.Descendants("h1").FirstOrDefault(x=>x.GetAttributeValue("class", "") == "vol-name");
                if (h1 == null)
                {
                    return null;
                }
                vol.VolName = h1.Descendants("span").FirstOrDefault(x => x.GetAttributeValue("class", "") == "vol-title").InnerText;
                vol.VolNumber = h1.Descendants("span").FirstOrDefault(x => x.GetAttributeValue("class", "") == "vol-number rounded").InnerText;
                #endregion

                #region 取关键字

                var keyNode = node.SelectNodes("//a")
                    .FirstOrDefault(x => x.GetAttributeValue("class", "") == "vol-tag-item");
                string keyword = keyNode == null ? "" : keyNode.InnerText;
                vol.VolKeyword = keyword.Replace("#", ",").Trim(',').Trim();

                #endregion

                #region 取期刊图片

                vol.VolPicUrl =
                    node.Descendants("img")
                        .FirstOrDefault(x => x.GetAttributeValue("class", "") == "vol-cover")
                        .Attributes["src"].Value;

                #endregion

                #endregion

                List<LuooSongModel> songs = new List<LuooSongModel>();

                #region 歌曲

                int index = 1;
                var divs = node.Descendants("div").Where(x => x.GetAttributeValue("class", "") == "player-wrapper");
                foreach (var d in divs)
                {
                    try
                    {
                        var imgElem = d.Descendants("img").FirstOrDefault();
                        var img = imgElem == null ? "" : imgElem.Attributes["src"].Value;
                        var ps = d.Descendants("p");
                        var name = ps.FirstOrDefault(x => x.GetAttributeValue("class", "") == "name").InnerText;
                        var artist = ps.FirstOrDefault(x => x.GetAttributeValue("class", "") == "artist").InnerText.Replace("Artist: ", "");
                        var album = ps.FirstOrDefault(x => x.GetAttributeValue("class", "") == "album").InnerText.Replace("Album: ", "");

                        LuooSongModel song = new LuooSongModel();
                        song.AddDate = DateTime.Now;
                        song.VolNo = volNo;
                        song.SongNo = Guid.NewGuid();
                        song.SongName = name.Trim();
                        string songId = index < 10 ? ("0" + index) : index.ToString();
                        song.DownloadUrl = "http://mp3-cdn2.luoo.net/low/luoo/radio" + vol.VolNumber.TrimStart('0') + "/" + songId + ".mp3";
                        song.Author = artist;
                        song.AlbumName = album;
                        song.ImgUrl = img;
                        songs.Add(song);
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    index++;
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


        public void test(string html)
        {

        }
    }


}
