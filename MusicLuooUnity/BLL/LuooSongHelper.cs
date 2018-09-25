using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamsoft.Data.Dapper;
using MusicLuooUnity.DAL;

namespace MusicLuooUnity.BLL
{
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
}
