# DR.Cache

<a href="https://github.com/DatReki/DR.Cache/actions/workflows/dotnet.yml">
    <img src="https://github.com/DatReki/DR.Cache/actions/workflows/dotnet.yml/badge.svg" />
</a>
<a href="https://www.nuget.org/packages/DR.Cache/">
    <img src="https://img.shields.io/nuget/v/DR.Cache?style=flat-square" />
</a>
<a href="https://www.paypal.com/donate?hosted_button_id=WRETYRRSJ4T2L">
    <img src="https://img.shields.io/badge/Donate-PayPal-green.svg?style=flat-square">
</a>

A small wrapper for Microsoft.Extensions.Caching.Memory 

## Usage
Here is an example on how you can use the library
```cs
using DR.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace SomeProjct
{
    public class Program
    {
        public partial class Data
        {
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public List<string> Tags { get; set; } = new();
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
            public double Price { get; set; }
        }

        static void Main(string[] args)
        {
            // Example data
            string keyName = "woodenDoor";
            Data productData = new Data()
            {
                Name = "Wooden door",
                Description = "Height: 1.2m. Width: 40cm. Depth: 5cm.",
                Tags = new() { "Door" , "Wood" },
                Created = DateTime.ParseExact("24/05/2019", "d/M/yyyy", CultureInfo.InvariantCulture),
                Updated = DateTime.ParseExact("04/08/2021", "d/M/yyyy", CultureInfo.InvariantCulture),
                Price = 45.64
            };
            double updatedPrice = 38.30;

            // Cache options
            MemoryCacheOptions options = new()
            {
                // The maximum amount of items in cache.
                SizeLimit = 100
            };

            // Global time for when cached items expire/get removed from cache
            TimeSpan cacheExperationTime = TimeSpan.FromSeconds(10);

            // Configure cache
            _ = new Configuration(cacheExperationTime, options);

            // Add item to cache
            Cache.Set(keyName, productData);

            // Check if item exists in cache
            if (Cache.Exists(keyName))
            {
                // Get item from cache
                productData = Cache.Get<Data>(keyName);

                // Update cached item
                productData.Price = updatedPrice;
                Cache.Update(keyName, productData);

                // Remove item from cache
                Cache.Remove(keyName);
            }
        }
    }
}
```

### Structure
The project has the following structure
* <strong>DR.Cache</strong>: This is the actual library
* <strong>DRN-Testing</strong>: Unit testing for the library