using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamsoft.Data.Dapper;
using MusicLuooUnity.DAL;

namespace MusicLuooUnity.BLL
{
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
                    if (datas.Contains(s)) continue;
                    datas.Add(s);
                }
            }
            return datas;
        }
    }
}
