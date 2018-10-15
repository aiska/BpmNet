using System;

namespace BpmNet.EntityFrameworkCore
{
    public class BpmNetEntityFrameworkCoreOptions
    {
        public Type DbContextType { get; set; }
        public bool EnableCaching { get; set; }
        public TimeSpan CacheExpiration { get; set; } = TimeSpan.FromSeconds(60);
    }
}