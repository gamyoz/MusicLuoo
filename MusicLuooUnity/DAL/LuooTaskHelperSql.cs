using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamsoft.Data.Dapper;

namespace MusicLuooUnity.DAL
{
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
