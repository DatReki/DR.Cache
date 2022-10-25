using DR.Cache;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.Caching.Memory;

namespace DRN_Testing
{
    [SetUpFixture]
    public class Main
    {
        [OneTimeSetUp]
        public void Setup()
        {
            MemoryCacheOptions options = new()
            {
                //The maximum amount of items in cache.
                SizeLimit = 100
            };

            _ = new Configuration(TimeSpan.FromSeconds(10), options);
        }
    }
}