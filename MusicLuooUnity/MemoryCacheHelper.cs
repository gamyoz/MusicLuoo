using System;
using System.Runtime.Caching;

namespace MusicLuooUnity
{
    public class MemoryCacheHelper
    {
        public static T Get<T>(string name)
        {
            try
            {
                ObjectCache cache = MemoryCache.Default;
                T model = (T)cache.Get(name);
                return model;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static bool Set<T>(string name, T model, DateTime expDateTime)
        {
            try
            {
                DateTimeOffset dt = new DateTimeOffset(expDateTime);
                ObjectCache cache = MemoryCache.Default;
                cache.Set(name, model, dt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
