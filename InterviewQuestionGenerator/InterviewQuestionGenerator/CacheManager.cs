using System;
using System.Collections;

namespace InterviewQuestionGenerator
{
    public class CacheManager
    {
        private static bool isFirstRun = true;

        public CacheManager()
        {
            if (isFirstRun)
            {
                Cache = new Hashtable();
                isFirstRun = false;
            }
        }

        private static Hashtable Cache { get; set; }

        internal static T GetObjectFromCache<T>(int hashCode)
        {
            var cachedObject = GetExistingObjectFromCache<T>(hashCode);

            if (cachedObject.IsObjectNull())
            {
                 var instance = default(T);
                AddObjectToCache(ref instance);
                return GetObjectFromCache<T>(instance.GetHashCode());
            }

            return cachedObject;
        }

        /// <summary>
        /// Gets the new or existing object from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>The existing object in the cache or a new instance of the target object</returns>
        private static T GetExistingObjectFromCache<T>(int hashCode)
        {
            if (Cache.ContainsKey(hashCode))
            {
                return (T)Cache[hashCode];
            }

            return default(T);
        }

        internal static void AddObjectToCache<T>(ref T instance)
        {
            if (instance.IsObjectNull())
            {
                instance = Activator.CreateInstance<T>();
            }
            
            Cache.Add(instance.GetHashCode(), instance);
        }
    }
}
