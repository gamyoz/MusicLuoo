using System;
using System.Collections.Generic;
using System.Text;
using Kamsoft.Data.Dapper;

namespace MusicLuooUnity
{
    public class LuooVolHelperSql : BaseDal, ILuooVolHelper
    {
        public void Add(LuooVolModel model)
        {
            const string sql =
                "insert into LuooVol(VolNo,VolKeyword,VolUrl,VolPicUrl,VolName,VolNumber,AddDate,VolPicLocalPath) values (@VolNo,@VolKeyword,@VolUrl,@VolPicUrl,@VolName,@VolNumber,@AddDate,@VolPicLocalPath)";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", model.VolNo);
            param.Add("VolKeyword", model.VolKeyword);
            param.Add("VolUrl", model.VolUrl);
            param.Add("VolPicUrl", model.VolPicUrl);
            param.Add("VolName", model.VolName);
            param.Add("VolNumber", model.VolNumber);
            param.Add("AddDate", model.AddDate);
            param.Add("VolPicLocalPath", model.VolPicLocalPath);
            Execute(sql, ref param);
        }

        public void AddList(List<LuooVolModel> models)
        {
            StringBuilder sql = new StringBuilder();
            foreach (var m in models)
            {
                sql.Append("insert into LuooVol(VolNo,VolKeyword,VolUrl,VolPicUrl,VolName,VolNumber,VolPicLocalPath,AddDate) values (");
                sql.AppendFormat("{0},", m.VolNo);
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolKeyword));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolUrl));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolPicUrl));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolName));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolNumber));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.VolPicLocalPath));
                sql.AppendFormat("'{0}');", m.AddDate);
            }
            DynamicParameters param = new DynamicParameters();
            Execute(sql.ToString(), ref param);
        }

        public void Update(LuooVolModel model)
        {
            const string sql =
                "update LuooVol set VolKeyword=@VolKeyword,VolUrl=@VolUrl,VolPicUrl=@VolPicUrl,VolName=@VolName,VolNumber=@VolNumber,AddDate=@AddDate,VolPicLocalPath=@VolPicLocalPath where VolNo=@VolNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", model.VolNo);
            param.Add("VolKeyword", model.VolKeyword);
            param.Add("VolUrl", model.VolUrl);
            param.Add("VolPicUrl", model.VolPicUrl);
            param.Add("VolName", model.VolName);
            param.Add("VolNumber", model.VolNumber);
            param.Add("AddDate", model.AddDate);
            param.Add("VolPicLocalPath", model.VolPicLocalPath);
            Execute(sql, ref param);
        }
        public void UpdateLocalPath(LuooVolModel model)
        {
            const string sql =
                "update LuooVol set VolPicLocalPath=@VolPicLocalPath where VolNo=@VolNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", model.VolNo);
            param.Add("VolPicLocalPath", model.VolPicLocalPath);
            Execute(sql, ref param);
        }

        public void Delete(int volNo)
        {
            DynamicParameters param = new DynamicParameters();
            string sql ="delete from LuooVol ";
            if (volNo > 0)
            {
                sql += " where VolNo=@VolNo";
                param.Add("VolNo", volNo);
            }
            Execute(sql, ref param);
        }

        public List<LuooVolModel> GetAll()
        {
            List<LuooVolModel> listCaches = UpdateCache();
            return listCaches;
        }

        public List<LuooVolModel> UpdateCache()
        {
            string volNo = string.Empty;
            try
            {
                const string sql = "select * from LuooVol";
                DynamicParameters param = new DynamicParameters();
                List<LuooVolModel> listCaches = Query<LuooVolModel>(sql, ref param);
                //MemoryCacheHelper.Set("LuooVolAllList", listCaches, DateTime.Now.AddHours(12));
                return listCaches;
            }
            catch (Exception ex)
            {
                LoggerUtil.ErrorLog("LuooVolHelper.UpdateCache:"+ volNo, ex);
                return null;
            }
        }

        public LuooVolModel GetByVolNo(int no)
        {
            //List<LuooVolModel> listCaches = MemoryCacheHelper.Get<List<LuooVolModel>>("LuooVolAllList");
            //if (listCaches != null)
            //{
            //    return listCaches.Find(x => x.VolNo == no);
            //}

            const string sql = "select * from LuooVol where VolNo=@VolNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", no);
            LuooVolModel model = QueryFirst<LuooVolModel>(sql, ref param);
            return model;
        }

        public List<LuooVolModel> GetListByLocalPath()
        {
            const string sql = "select top 100 * from LuooVol with(nolock) where isnull(VolPicLocalPath,'')=''";
            DynamicParameters param = new DynamicParameters();
            List<LuooVolModel> listCaches = Query<LuooVolModel>(sql, ref param);
            return listCaches;
        }

        public List<string> GetVolKeywords()
        {
            const string sql = "select distinct VolKeyword from LuooVol with(nolock) where VolKeyword is not null and VolKeyword<>''";
            DynamicParameters param = new DynamicParameters();
            List<string> listCaches = Query<string>(sql, ref param);
            return listCaches;
        }
    }

    public class LuooSongHelperSql : BaseDal, ILuooSongHelper
    {
        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        public int GetAllCount()
        {
            string sql = "select count(1) from LuooSong with(nolock) ";
            DynamicParameters param = new DynamicParameters();
            return Count(sql, ref param);
        }

        public void Add(LuooSongModel model)
        {
            const string sql =
                "insert into LuooSong(VolNo,SongNo,SongName,DownloadUrl,AlbumName,Author,AddDate,LocalPath) values (@VolNo,@SongNo,@SongName,@DownloadUrl,@AlbumName,@Author,@AddDate,@LocalPath)";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", model.VolNo);
            param.Add("SongNo", model.SongNo);
            param.Add("SongName", model.SongName);
            param.Add("DownloadUrl", model.DownloadUrl);
            param.Add("AlbumName", model.AlbumName);
            param.Add("Author", model.Author);
            param.Add("AddDate", model.AddDate);
            param.Add("LocalPath", model.LocalPath);
            Execute(sql, ref param);
        }

        public void AddList(List<LuooSongModel> models)
        {
            StringBuilder sql = new StringBuilder();
            foreach (var m in models)
            {
                sql.Append("insert into LuooSong(VolNo,SongNo,SongName,DownloadUrl,AlbumName,Author,LocalPath,AddDate) values (");
                sql.AppendFormat("{0},", m.VolNo);
                sql.AppendFormat("'{0}',", m.SongNo);
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.SongName));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.DownloadUrl));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.AlbumName));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.Author));
                sql.AppendFormat("'{0}',", Common.GetSqlParam(m.LocalPath));
                sql.AppendFormat("'{0}');", m.AddDate);
            }
            DynamicParameters param = new DynamicParameters();
            Execute(sql.ToString(), ref param);
        }

        public void Update(LuooSongModel model)
        {
            const string sql =
                   "update LuooSong set VolNo=@VolNo,SongName=@SongName,DownloadUrl=@DownloadUrl,AlbumName=@AlbumName,Author=@Author,AddDate=@AddDate,LocalPath=@LocalPath where SongNo=@SongNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("VolNo", model.VolNo);
            param.Add("SongNo", model.SongNo);
            param.Add("SongName", model.SongName);
            param.Add("DownloadUrl", model.DownloadUrl);
            param.Add("AlbumName", model.AlbumName);
            param.Add("Author", model.Author);
            param.Add("AddDate", model.AddDate);
            param.Add("LocalPath", model.LocalPath);
            Execute(sql, ref param);
        }

        public void UpdateLocalPath(LuooSongModel model)
        {
            const string sql =
                   "update LuooSong set LocalPath=@LocalPath where SongNo=@SongNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("SongNo", model.SongNo);
            param.Add("LocalPath", model.LocalPath);
            Execute(sql, ref param);
        }

        public void Delete(Guid songNo)
        {
            DynamicParameters param = new DynamicParameters();
            string sql = "delete from LuooSong ";
            if (songNo != Guid.Empty)
            {
                sql += " where SongNo=@SongNo";
                param.Add("SongNo", songNo);
            }
            Execute(sql, ref param);
        }

        public List<LuooVolSongModel> GetAll()
        {
            List<LuooVolSongModel> listCaches = UpdateCache(0);
            return listCaches;
        }

        public List<LuooVolSongModel> UpdateCache(int top)
        {
            string sql = string.Format(@"select {0} a.*,b.VolKeyword,b.VolUrl,b.VolPicUrl,b.VolName,b.VolNumber,b.VolPicLocalPath 
                                         from LuooSong a with(nolock) 
                                         join LuooVol b with(nolock) on a.VolNo=b.VolNo 
                                         order by a.SongIndex", top >0 ?("top " + top) :"");
            DynamicParameters param = new DynamicParameters();
            List<LuooVolSongModel> listCaches = Query<LuooVolSongModel>(sql, ref param);
            //MemoryCacheHelper.Set("LuooSongAllList", listCaches, DateTime.Now.AddHours(12));
            return listCaches;
        }

        public List<LuooVolSongModel> GetListPager(int pageIndex, int pageSize, string keywords)
        {
            string where = string.Empty;
            if (!string.IsNullOrEmpty(keywords))
            {
                List<string> w = new List<string>();
                foreach (var k in keywords.Split(','))
                {
                    w.Add("(','+b.VolKeyword+',') like '%," + k+",%'");
                }
                where = "where " + string.Join(" or ", w);
            }
            string sql = string.Format(@"select a.*,b.VolKeyword,b.VolUrl,b.VolPicUrl,b.VolName,b.VolNumber,b.VolPicLocalPath 
                                         from LuooSong a with(nolock) 
                                         join LuooVol b with(nolock) on a.VolNo=b.VolNo 
                                         {2}
                                         order by a.SongIndex desc
                                         OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", (pageIndex - 1) * pageSize, pageSize, where);
            DynamicParameters param = new DynamicParameters();
            List<LuooVolSongModel> listCaches = Query<LuooVolSongModel>(sql, ref param);
            return listCaches;
        }


        public LuooSongModel GetByVolNo(Guid no)
        {
            //List<LuooSongModel> listCaches = MemoryCacheHelper.Get<List<LuooSongModel>>("LuooSongAllList");
            //if (listCaches != null)
            //{
            //    return listCaches.Find(x => x.SongNo == no);
            //}

            const string sql = "select * from LuooSong where SongNo=@SongNo";
            DynamicParameters param = new DynamicParameters();
            param.Add("SongNo", no);
            LuooSongModel model = QueryFirst<LuooSongModel>(sql, ref param);
            return model;
        }
        public List<LuooSongModel> GetListByLocalPath()
        {
            const string sql = "select top 100 * from LuooSong with(nolock) where isnull(LocalPath,'')=''";
            DynamicParameters param = new DynamicParameters();
            List<LuooSongModel> listCaches = Query<LuooSongModel>(sql, ref param);
            return listCaches;
        }
    }

    public class LuooTaskHelperSql : BaseDal, ILuooTaskHelper
    {
        public void Add(LuooTaskModel model)
        {
            const string sql =
                "insert into LuooTask(Id,TotalTaskCount,CurrentTaskCount,AddTime,UpdateTime) values (@Id,@TotalTaskCount,@CurrentTaskCount,@AddTime,@UpdateTime)";
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", model.Id);
            param.Add("TotalTaskCount", model.TotalTaskCount);
            param.Add("CurrentTaskCount", model.CurrentTaskCount);
            param.Add("AddTime", model.AddTime);
            param.Add("UpdateTime", model.UpdateTime);
            Execute(sql, ref param);
        }

        public void Update(string id, int currCount)
        {
            const string sql = "update LuooTask set CurrentTaskCount+=@CurrentTaskCount,UpdateTime=getdate() where Id=@Id";
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", id);
            param.Add("CurrentTaskCount", currCount);
            Execute(sql, ref param);
        }

        public LuooTaskModel GetTaskById(string id)
        {
            const string sql = "select * from LuooTask where Id=@Id";
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", id);
            return QueryFirst<LuooTaskModel>(sql, ref param);
        }
    }
}
