// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="CollectionExtensions.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StandAloneFramework.Extensions
{
    /// <summary>
    /// Represents a collection of extensions that can be used on a concrete implementation of the ICollection interface i.e. List, IEnumerable, IList, Dictionary etc
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="value">The value.</param>
        internal static void AddToList<T>(this IList<T> sourceList, T value)
        {
            sourceList.Add(value);
        }

        /// <summary>
        /// Gets the key based on the value passed into the dictionary. By default the Dictionary does not actively support this functionality thus the extension method was needed
        /// </summary>
        /// <typeparam name="T1">The type of the key.</typeparam>
        /// <typeparam name="T2">The type of the value.</typeparam>
        /// <param name="targetDictionary">The target dictionary.</param>
        /// <param name="targetValue">The target value.</param>
        /// <returns>System.Object.</returns>
        internal static object GetKey<T1, T2>(this Dictionary<T1, T2> targetDictionary, object targetValue)
        {
            var sortedList = new SortedList();

            targetDictionary.Keys.ToList().ForEach(key => sortedList.Add(key, targetDictionary[key]));

            return sortedList.GetKey(sortedList.IndexOfValue(targetValue));
        }
    }
}
