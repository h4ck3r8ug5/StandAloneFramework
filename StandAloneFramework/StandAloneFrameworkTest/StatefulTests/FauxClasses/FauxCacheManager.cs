using System;
using StandAloneFramework;
using StandAloneFramework.Interfaces;

namespace StandAloneFrameworkTest.StatefulTests.FauxClasses
{
    public class FauxCacheManager : FauxManager, ICacheManager<Object>
    {
        public void AddObjectToCache(object instance)
        {
            IsMethodIvoked = true;
        }

        public object GetObjectFromCache(int hashCode)
        {
            IsMethodIvoked = true;
            return IsMethodIvoked;
        }

        public void FlushCache()
        {
            IsMethodIvoked = true;
        }       
    }
}
