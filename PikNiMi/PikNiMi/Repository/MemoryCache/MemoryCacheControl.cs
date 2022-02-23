using System;
using Microsoft.Extensions.Caching.Memory;

namespace PikNiMi.Repository.MemoryCache
{
    public class MemoryCacheControl
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheControl(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetNewStringValueToCache(string newcacheKey, string value, int minutes)
        {
            _memoryCache.Set(newcacheKey, value, TimeSpan.FromMinutes(minutes));
        }

        public string GetExistingStringDataFromCache(string cacheKey)
        {
            string value = _memoryCache.Get<string>(cacheKey);
            return value;
        }

        public void DeleteExistingCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
