using System;
using StandAloneFramework;
using StandAloneFramework.Interfaces;

namespace StandAloneFrameworkTest.StatefulTests.FauxClasses
{
    public class FauxCacheManager : FauxManager, ICacheManager<Object>
    {
        public object AddObjectToCache(object instance)
        {
            IsMethodIvoked = true;
            return IsMethodIvoked;
        }

        public object GetObjectFromCache(int hashCode)
        {
            IsMethodIvoked = true;
            return IsMethodIvoked;
        }

        public bool FlushCache()
        {
            return IsMethodIvoked = true;
        }
    }
}
