using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using System.Text;
using static DR.Cache.Errors;

namespace DR.Cache
{
    public class Cache
    {
        private static string s_cacheNotFound = "Unable to {0} cached item. Cannot find item with the following key '{1}'";

        #region Get object
        /// <summary>
        /// Get value from Cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return Configuration.s_cache.Get(key);
        }
        #endregion

        #region Get generic
        /// <summary>
        /// Get value from Cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return Configuration.s_cache.Get<T>(key);
        }
        #endregion

        #region Exists
        /// <summary>
        /// Check if cached item exists
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return Configuration.s_cache.TryGetValue(key, out _);
        }
        #endregion

        #region Exists generic
        /// <summary>
        /// Check if cached item exists
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <returns></returns>
        public static bool Exists<T>(string key)
        {
            return Configuration.s_cache.TryGetValue<T>(key, out _);
        }
        #endregion

        #region TryGetValue object
        /// <summary>
        /// Try to get value from Cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="result">Value of item if it is cached</param>
        /// <returns></returns>
        public static bool TryGetValue(string key, out object result)
        {
            return Configuration.s_cache.TryGetValue(key, out result);
        }
        #endregion

        #region TryGetValue generic
        /// <summary>
        /// Try to get value from Cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="result">Value of item if it is cached</param>
        /// <returns></returns>
        public static bool TryGetValue<T>(string key, out T result)
        {
            return Configuration.s_cache.TryGetValue<T>(key, out result);
        }
        #endregion

        #region Set object
        /// <summary>
        /// Add an item to cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="value">Value of the item being cached</param>
        public static void Set(string key, object value)
        {
            BaseMethods.Set(key, 1, Configuration.s_experationTimer, value);
        }

        /// <summary>
        /// Add an item to cache
        /// </summary>
		/// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
		/// <param name="value">Value of the item being cached</param>
        public static void Set(string key, TimeSpan time, object value)
        {
            BaseMethods.Set(key, 1, time, value);
        }
        
        /// <summary>
        /// Add an item to cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="size">Size of the item being cached</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="value">Value of the item being cached</param>
        public static void Set(string key, int size, TimeSpan time, object value)
        {
            BaseMethods.Set(key, size, time, value);
        }
        #endregion

        #region Set generic
        /// <summary>
        /// Add an item to cache
        /// </summary>
		/// <param name="key">Key of the cached item</param>
		/// <param name="value">Value of the item being cached</param>
        public static void Set<T>(string key, T value)
        {
            BaseMethods.Set(key, 1, Configuration.s_experationTimer, value);
        }

        /// <summary>
        /// Add an item to cache
        /// </summary>
		/// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
		/// <param name="value">Value of the item being cached</param>
        public static void Set<T>(string key, TimeSpan time, T value)
        {
            BaseMethods.Set(key, 1, time, value);
        }

        /// <summary>
        /// Add an item to cache
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="size">Size of the item being cached</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="value">Value of the item being cached</param>
        public static void Set<T>(string key, int size, TimeSpan time, T value)
        {
            BaseMethods.Set(key, size, time, value);
        }
        #endregion

        #region Update object
        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update(string key, object value)
        {
            BaseMethods.Update(key, 1, Configuration.s_experationTimer, value);
        }

        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update(string key, TimeSpan time, object value)
        {
            BaseMethods.Update(key, 1, time, value);
        }

        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="size">Size of the cached item being updated</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update(string key, int size, TimeSpan time, object value)
        {
            BaseMethods.Update(key, 1, time, value);
        }
        #endregion

        #region Update generic
        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update<T>(string key, T value)
        {
            BaseMethods.Update(key, 1, Configuration.s_experationTimer, value);
        }

        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update<T>(string key, TimeSpan time, T value)
        {
            BaseMethods.Update(key, 1, time, value);
        }

        /// <summary>
        /// Update a cached item
        /// </summary>
        /// <param name="key">Key of the cached item</param>
        /// <param name="time">Time when the cached item expires</param>
        /// <param name="size">Size of the cached item being updated</param>
        /// <param name="value">Value you want the cached item to be updated with</param>
        public static void Update<T>(string key, int size, TimeSpan time, T value)
        {
            BaseMethods.Update(key, 1, time, value);
        }
        #endregion

        #region Remove
        /// <summary>
        /// Remove a item from cache
        /// </summary>
        /// <param name="key">Key of the item you want to remove from cache</param>
        /// <exception cref="CacheNotFoundException"></exception>
        public static void Remove(string key)
        {
            try
            {
                Configuration.s_cache.Remove(key);
            }
            catch
            {
                throw new CacheNotFoundException(string.Format(s_cacheNotFound, "remove", key));
            }
        }
        #endregion

        internal partial class BaseMethods
        {
            #region Set object
            /// <summary>
            /// Base method for creating 
            /// </summary>
            /// <param name="key">Key of the cached item</param>
            /// <param name="size">Size of the item being cached</param>
            /// <param name="time">Time when the cached item expires</param>
            /// <param name="value">Value of the item being cached</param>
            internal static void Set(string key, int size, TimeSpan time, object value)
            {
                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(size)                  // Size amount
                    .SetAbsoluteExpiration(time);   // Remove from cache after this time
                                                    // Save data in cache
                Configuration.s_cache.Set(key, value, cacheEntryOptions);
            }
            #endregion

            #region Set generic
            /// <summary>
            /// Base method for creating 
            /// </summary>
            /// <param name="key">Key of the cached item</param>
            /// <param name="size">Size of the item being cached</param>
            /// <param name="time">Time when the cached item expires</param>
            /// <param name="value">Value of the item being cached</param>
            internal static void Set<T>(string key, int size, TimeSpan time, T value)
            {
                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(size)                  // Size amount
                    .SetAbsoluteExpiration(time);   // Remove from cache after this time
                                                    // Save data in cache
                Configuration.s_cache.Set(key, value, cacheEntryOptions);
            }
            #endregion

            #region Update object
            /// <summary>
            /// Update a cached item
            /// </summary>
            /// <param name="key">Key of the cached item</param>
            /// <param name="time">Time when the cached item expires</param>
            /// <param name="size">Size of the cached item being updated</param>
            /// <param name="value">Value you want the cached item to be updated with</param>
            /// <exception cref="CacheNotFoundException"></exception>
            internal static void Update(string key, int size, TimeSpan time, object value)
            {
                // Check if item is even in cache
                if (Exists(key))
                {
                    // Remove old item from cache
                    Remove(key);
                    // Re-add item
                    Set(key, size, time, value);
                }
                else
                {
                    throw new CacheNotFoundException(string.Format(s_cacheNotFound, "update", key));
                }
            }
            #endregion

            #region Update generic
            /// <summary>
            /// Update a cached item
            /// </summary>
            /// <param name="key">Key of the cached item</param>
            /// <param name="time">Time when the cached item expires</param>
            /// <param name="size">Size of the cached item being updated</param>
            /// <param name="value">Value you want the cached item to be updated with</param>
            /// <exception cref="CacheNotFoundException"></exception>
            internal static void Update<T>(string key, int size, TimeSpan time, T value)
            {
                // Check if item is even in cache
                if (Exists(key))
                {
                    // Remove old item from cache
                    Remove(key);
                    // Re-add item
                    Set(key, size, time, value);
                }
                else
                {
                    throw new CacheNotFoundException(string.Format(s_cacheNotFound, "update", key));
                }
            }
            #endregion
        }
    }
}