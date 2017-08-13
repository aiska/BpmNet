using System;
using System.Runtime.Caching;

namespace BPMNET.EntityCore
{
    internal class Cache
    {
        private static int secExp = 60;
        public static void Add(string key, object item) {
            MemoryCache.Default.Add(key, item, DateTimeOffset.Now.AddSeconds(secExp));
        }

        public static void Set(string key, object item)
        {
            MemoryCache.Default.Set(key, item, DateTimeOffset.Now.AddSeconds(secExp));
        }

        public static void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public static object Get(string key)
        {
            return MemoryCache.Default.Get(key);
        }
    }
}
