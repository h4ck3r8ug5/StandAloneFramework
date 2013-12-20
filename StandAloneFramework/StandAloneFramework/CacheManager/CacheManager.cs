using System;
using System.Collections;
using StandAloneFramework.Extensions;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    public class CacheManager<T> : ICacheManager<T>    {
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

            var instance = Activator.CreateInstance<T>();

            AddObjectToCache(instance);

            return GetObjectFromCache(instance.GetHashCode());
        }

        public void FlushCache()
        {
        }        
    }
}
