using System.Collections.Generic;

namespace Tekus.Persistence.Cache
{
    public static class CacheHandler
    {
        private readonly static IDictionary<string, object> data;

        static CacheHandler()
        {
            data = new Dictionary<string, object>();
        }

        public static IDictionary<string, object> Data { get { return data; } }

        public static void ClearCache()
        {
            data.Clear();
        }

    }
}
