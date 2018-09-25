using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamsoft.Data.Dapper;
using MusicLuooUnity.DAL;

namespace MusicLuooUnity.BLL
{
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
}
