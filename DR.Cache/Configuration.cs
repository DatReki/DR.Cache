using System;
using Microsoft.Extensions.Caching.Memory;

namespace DR.Cache
{
    public class Configuration
    {
        public Configuration(TimeSpan experationTimer, MemoryCacheOptions options)
        {
            s_experationTimer = experationTimer;
            s_cache = new MemoryCache(options);
        }

        internal static TimeSpan s_experationTimer { get; private set; }
        internal static MemoryCache s_cache { get; private set; } = new MemoryCache(new MemoryCacheOptions());
    }
}