using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StandAloneFramework.Extensions
{
    public static class CollectionExtensions
    {       
        internal static void AddToList<T>(this IList<T> sourceList, T value)
        {
            sourceList.Add(value);
        }

        internal static object GetKey<T1, T2>(this Dictionary<T1, T2> targetDictionary, object targetValue)
        {
            var sortedList = new SortedList();

            targetDictionary.Keys.ToList().ForEach(key => sortedList.Add(key, targetDictionary[key]));

            return sortedList.GetKey(sortedList.IndexOfValue(targetValue));
        }
    }
}
