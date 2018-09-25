using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MusicLuooUnity
{
    public class LuooVolHelperXml
    {
        public static string VolXmlPath = AppDomain.CurrentDomain.BaseDirectory + "/data/vol.xml";

        public void Add(LuooVolModel model)
        {
            XDocument doc = XDocument.Load(VolXmlPath);
            XElement newX = new XElement("v");
            newX.SetAttributeValue("VolNo", model.VolNo);
            newX.SetAttributeValue("VolKeyword", model.VolKeyword);
            newX.SetAttributeValue("VolUrl", model.VolUrl);
            newX.SetAttributeValue("VolPicUrl", model.VolPicUrl);
            newX.SetAttributeValue("VolName", model.VolName);
            newX.SetAttributeValue("VolNumber", model.VolNumber);
            newX.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
            doc.Descendants("vol").First().Add(newX);
            doc.Save(VolXmlPath);
        }

        public void AddList(List<LuooVolModel> models)
        {
            XDocument doc = XDocument.Load(VolXmlPath);
            var vol = doc.Descendants("vol").First();
            foreach (var model in models)
            {
                XElement newX = new XElement("v");
                newX.SetAttributeValue("VolNo", model.VolNo);
                newX.SetAttributeValue("VolKeyword", model.VolKeyword);
                newX.SetAttributeValue("VolUrl", model.VolUrl);
                newX.SetAttributeValue("VolPicUrl", model.VolPicUrl);
                newX.SetAttributeValue("VolName", model.VolName);
                newX.SetAttributeValue("VolNumber", model.VolNumber);
                newX.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
                vol.Add(newX);
            }
            doc.Save(VolXmlPath);
        }

        public void Update(LuooVolModel model)
        {
            XDocument doc = XDocument.Load(VolXmlPath);
            var xele = doc.Descendants("v").FirstOrDefault(x => int.Parse(x.Attribute("VolNo").Value) == model.VolNo);
            xele.SetAttributeValue("VolKeyword", model.VolKeyword);
            xele.SetAttributeValue("VolUrl", model.VolUrl);
            xele.SetAttributeValue("VolPicUrl", model.VolPicUrl);
            xele.SetAttributeValue("VolName", model.VolName);
            xele.SetAttributeValue("VolNumber", model.VolNumber);
            xele.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
            doc.Save(VolXmlPath);
        }

        public void Delete(int volNo)
        {
            XDocument doc = XDocument.Load(VolXmlPath);
            doc.Descendants("v").FirstOrDefault(x => int.Parse(x.Attribute("VolNo").Value) == volNo).Remove();
            doc.Save(VolXmlPath);
        }

        public List<LuooVolModel> GetAll()
        {
            List<LuooVolModel> listCaches = MemoryCacheHelper.Get<List<LuooVolModel>>("LuooVolAllList");
            if (listCaches == null)
            {
                listCaches = UpdateCache();
            }
            return listCaches;
        }

        public List<LuooVolModel> UpdateCache()
        {
            string volNo = string.Empty;
            try
            {
                List<LuooVolModel> listCaches = new List<LuooVolModel>();
                XDocument doc = XDocument.Load(VolXmlPath);
                var xDesc = doc.Descendants("v");
                foreach (var xElement in xDesc)
                {
                    volNo = GetValue("VolNo", xElement);
                    listCaches.Add(new LuooVolModel
                    {
                        VolNo = int.Parse(volNo),
                        AddDate = DateTime.Parse(GetValue("AddDate", xElement)),
                        VolPicUrl = GetValue("VolPicUrl", xElement),
                        VolUrl = GetValue("VolUrl", xElement),
                        VolKeyword = GetValue("VolKeyword", xElement),
                        VolName = GetValue("VolName", xElement),
                        VolNumber = GetValue("VolNumber", xElement),
                    });
                }
                MemoryCacheHelper.Set("LuooVolAllList", listCaches, DateTime.Now.AddHours(12));
                return listCaches;
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("LuooVolHelper.UpdateCache:"+ volNo, ex);
                return null;
            }
        }

        private string GetValue(string name, XElement xElement)
        {
            return xElement.Attribute(name) != null ? xElement.Attribute(name).Value : "";
        }

        public LuooVolModel GetByVolNo(int no)
        {
            List<LuooVolModel> listCaches = MemoryCacheHelper.Get<List<LuooVolModel>>("LuooVolAllList");
            if (listCaches != null)
            {
                return listCaches.Find(x => x.VolNo == no);
            }

            XDocument doc = XDocument.Load(VolXmlPath);
            var xElement = doc.Descendants("v").FirstOrDefault(x => int.Parse(x.Attribute("VolNo").Value) == no);
            if (xElement == null) return null;
            LuooVolModel model = new LuooVolModel
            {
                VolNo = int.Parse(xElement.Attribute("VolNo").Value),
                AddDate = DateTime.Parse(xElement.Attribute("AddDate").Value),
                VolPicUrl = xElement.Attribute("VolPicUrl").Value,
                VolUrl = xElement.Attribute("VolUrl").Value,
                VolKeyword = xElement.Attribute("VolKeyword").Value,
                VolName = xElement.Attribute("VolName").Value,
                VolNumber = xElement.Attribute("VolNumber").Value,
            };
            return model;
        }
    }

    public class LuooSongHelperXml
    {
        public static string SongXmlPath = AppDomain.CurrentDomain.BaseDirectory + "/data/song.xml";

        public void Add(LuooSongModel model)
        {
            XDocument doc = XDocument.Load(SongXmlPath);
            XElement newX = new XElement("s");
            newX.SetAttributeValue("VolNo", model.VolNo);
            newX.SetAttributeValue("SongNo", model.SongNo);
            newX.SetAttributeValue("SongName", model.SongName);
            newX.SetAttributeValue("DownloadUrl", model.DownloadUrl);
            newX.SetAttributeValue("AlbumName", model.AlbumName);
            newX.SetAttributeValue("Author", model.Author);
            newX.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
            doc.Descendants("song").First().Add(newX);
            doc.Save(SongXmlPath);
        }

        public void AddList(List<LuooSongModel> models)
        {
            XDocument doc = XDocument.Load(SongXmlPath);
            var vol = doc.Descendants("song").First();
            foreach (var model in models)
            {
                XElement newX = new XElement("s");
                newX.SetAttributeValue("VolNo", model.VolNo);
                newX.SetAttributeValue("SongNo", model.SongNo);
                newX.SetAttributeValue("SongName", model.SongName);
                newX.SetAttributeValue("DownloadUrl", model.DownloadUrl);
                newX.SetAttributeValue("AlbumName", model.AlbumName);
                newX.SetAttributeValue("Author", model.Author);
                newX.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
                vol.Add(newX);
            }
            doc.Save(SongXmlPath);
        }

        public void Update(LuooSongModel model)
        {
            XDocument doc = XDocument.Load(SongXmlPath);
            var xele = doc.Descendants("s").FirstOrDefault(x => x.Attribute("SongNo").Value == model.SongNo.ToString());
            xele.SetAttributeValue("VolNo", model.VolNo);
            xele.SetAttributeValue("SongName", model.SongName);
            xele.SetAttributeValue("DownloadUrl", model.DownloadUrl);
            xele.SetAttributeValue("AlbumName", model.AlbumName);
            xele.SetAttributeValue("Author", model.Author);
            xele.SetAttributeValue("AddDate", model.AddDate.ToString("yyyy-MM-dd"));
            doc.Save(SongXmlPath);
        }

        public void Delete(Guid songNo)
        {
            XDocument doc = XDocument.Load(SongXmlPath);
            doc.Descendants("s").FirstOrDefault(x => x.Attribute("SongNo").Value == songNo.ToString()).Remove();
            doc.Save(SongXmlPath);
        }

        public List<LuooVolSongModel> GetAll()
        {
            List<LuooVolSongModel> listCaches = MemoryCacheHelper.Get<List<LuooVolSongModel>>("LuooSongAllList");
            if (listCaches == null || listCaches.Count == 0)
            {
                listCaches = UpdateCache(0);
            }
            return listCaches;
        }

        public List<LuooVolSongModel> UpdateCache(int top)
        {
            var listCaches = new List<LuooVolSongModel>();
            XDocument doc = XDocument.Load(SongXmlPath);
            var xDesc = doc.Descendants("s");
            foreach (var xElement in xDesc)
            {
                listCaches.Add(new LuooVolSongModel
                {
                    SongNo = Guid.Parse(GetValue("SongNo", xElement)),
                    VolNo = int.Parse(GetValue("VolNo", xElement)),
                    AddDate = DateTime.Parse(GetValue("AddDate", xElement)),
                    SongName = GetValue("SongName", xElement),
                    Author = GetValue("Author", xElement),
                    AlbumName = GetValue("AlbumName", xElement),
                    DownloadUrl = GetValue("DownloadUrl", xElement),
                });
            }
            MemoryCacheHelper.Set("LuooSongAllList", listCaches, DateTime.Now.AddHours(12));
            return listCaches;
        }

        private string GetValue(string name, XElement xElement)
        {
            return xElement.Attribute(name) != null ? xElement.Attribute(name).Value : "";
        }


        public LuooSongModel GetByVolNo(Guid no)
        {
            List<LuooSongModel> listCaches = MemoryCacheHelper.Get<List<LuooSongModel>>("LuooSongAllList");
            if (listCaches != null)
            {
                return listCaches.Find(x => x.SongNo == no);
            }

            XDocument doc = XDocument.Load(SongXmlPath);
            var xElement = doc.Descendants("v").FirstOrDefault(x => x.Attribute("SongNo").Value == no.ToString());
            if (xElement == null) return null;
            LuooSongModel model = new LuooSongModel
            {
                SongNo = Guid.Parse(xElement.Attribute("SongNo").Value),
                VolNo = int.Parse(xElement.Attribute("VolNo").Value),
                AddDate = DateTime.Parse(xElement.Attribute("AddDate").Value),
                SongName = xElement.Attribute("SongName").Value,
                Author = xElement.Attribute("Author").Value,
                AlbumName = xElement.Attribute("AlbumName").Value,
                DownloadUrl = xElement.Attribute("DownloadUrl").Value,
            };
            return model;
        }
    }
}
