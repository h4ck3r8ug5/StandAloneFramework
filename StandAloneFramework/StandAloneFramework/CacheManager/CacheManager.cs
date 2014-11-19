// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="CacheManager.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    /// <summary>
    /// Acts as a central store for all objects who need to be cached
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheManager<T> : ICacheManager<T>    
    {
        /// <summary>
        /// Represents the reasons for flushing the cache
        /// </summary>
        [Obsolete("This will be implemented later on. Do not use.")]
        protected enum CacheFlushReason
        {
            /// <summary>
            /// Represents the default reason for the cache being flushed. Will expand on this soon
            /// </summary>
            Default
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheManager{T}"/> class.
        /// </summary>
        public CacheManager()
        {
            Cache = new Hashtable();
            Instance = Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets or sets the instance of the object to either be stored in the cache store or that is retrieved from the cache store.
        /// </summary>
        /// <value>The instance.</value>
        protected T Instance { get; set; }

        /// <summary>
        /// Gets or sets the cache store. This is of type HashSet as its based on the Key, Value pairs and it needs to be frequently searched
        /// </summary>
        /// <value>The cache.</value>
        private Hashtable Cache { get; set; }

        /// <summary>
        /// Adds the object to cache store.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void AddObjectToCache(T instance)
        {
            Cache.Add(instance.GetHashCode(), instance);
        }

        /// <summary>
        /// Gets the object from cache store.
        /// </summary>
        /// <param name="hashCode">The hash code.</param>
        /// <returns>T.</returns>
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

        /// <summary>
        /// Flushes the cache store.
        /// </summary>
        public void FlushCache()
        {
        }        
    }
}
