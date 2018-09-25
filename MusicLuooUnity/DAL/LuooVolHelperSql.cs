using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamsoft.Data.Dapper;

namespace MusicLuooUnity.DAL
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
            string sql = "delete from LuooVol ";
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
                LoggerUtil.ErrorLog("LuooVolHelper.UpdateCache:" + volNo, ex);
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
}
