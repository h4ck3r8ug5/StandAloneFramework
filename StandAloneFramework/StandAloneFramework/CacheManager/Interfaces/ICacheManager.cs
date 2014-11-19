// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="ICacheManager.cs" company="">
//     Copyright (c) 2015. rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace StandAloneFramework.Interfaces
{
    /// <summary>
    /// The CacheManager's contract
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICacheManager<T>
    {
        /// <summary>
        /// Adds the object to cache store.
        /// </summary>
        /// <param name="instance">The instance.</param>
        void AddObjectToCache(T instance);

        /// <summary>
        /// Gets the object from cache store.
        /// </summary>
        /// <param name="hashCode">The hash code.</param>
        /// <returns>T.</returns>
        T GetObjectFromCache(int hashCode);

        /// <summary>
        /// Flushes the cache store.
        /// </summary>
        void FlushCache();
    }
}
