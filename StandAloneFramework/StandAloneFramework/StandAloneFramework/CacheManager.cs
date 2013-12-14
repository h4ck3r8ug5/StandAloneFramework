using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StandAloneFramework.Extensions;

namespace StandAloneFramework
{
    public class CacheManager<T> : ICacheManager<T>
    {
        [Obsolete("This will be implemented later on. Do not use.")]
        protected enum CacheFlushReason
        {
            /// <summary>
            /// Represents the default reason for the cache being flushed. Will expand on this soon
            /// </summary>
            Default
        }

        public CacheManager()
        {
            Cache = new Hashtable();
            Instance = Activator.CreateInstance<T>();
        }

        protected T Instance { get; set; }

        private Hashtable Cache { get; set; }

        public void AddObjectToCache(T instance)
        {
            Cache.Add(instance.GetHashCode(), instance);
        }

        public T GetObjectFromCache(int hashCode)
        {
            if (Cache.ContainsKey(hashCode))
            {
                return (T)Cache[hashCode];
            }

            AddObjectToCache(Instance);

            return GetObjectFromCache(Instance.GetHashCode());
        }

        public void FlushCache()
        {
            foreach (var cacheItem in Cache)
            {
                object boxedItem;
                if (cacheItem is Thread)
                {
                    boxedItem = (Thread)cacheItem;
                    if (boxedItem.ThreadState == ThreadState.Aborted || cacheItem.ThreadState == ThreadState.Stopped)
                    {
                        Cache.Remove(cacheItem);
                    }
                }
            }
        }
    }
}
