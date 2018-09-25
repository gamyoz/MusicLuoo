using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLuooUnity
{
    public interface ILuooVolHelper
    {
        void Add(LuooVolModel model);
        void AddList(List<LuooVolModel> models);
        void Update(LuooVolModel model);
        void Delete(int volNo);
        List<LuooVolModel> GetAll();
        List<LuooVolModel> UpdateCache();
        LuooVolModel GetByVolNo(int no);
        List<LuooVolModel> GetListByLocalPath();
        void UpdateLocalPath(LuooVolModel model);
        List<string> GetVolKeywords();
        int GetMaxVolNo();
    }

    public interface ILuooSongHelper
    {
        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        int GetAllCount();
        void Add(LuooSongModel model);
        void AddList(List<LuooSongModel> models);
        void Update(LuooSongModel model);
        void Delete(Guid songNo);
        List<LuooVolSongModel> GetAll();
        List<LuooVolSongModel> UpdateCache(int top);
        LuooSongModel GetByVolNo(Guid no);
        List<LuooSongModel> GetListByLocalPath();
        void UpdateLocalPath(LuooSongModel model);
        List<LuooVolSongModel> GetListPager(int pageIndex, int pageSize, string keywords);
    }

    public interface ILuooTaskHelper
    {
        void Add(LuooTaskModel model);
        void Update(string id, int currCount);
        LuooTaskModel GetTaskById(string id);
    }
}
