using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFrameworkTest.IntegrationTests.CacheManager
{
    [TestClass]
    public class CacheManagerTestFixture
    {        
        [TestMethod]
        public void AddObjectToCacheTest()
        {
            var cacheManager = new CacheManager<InvocationResult>();
            
            var expectedCacheObject = new InvocationResult();

            cacheManager.AddObjectToCache(expectedCacheObject);

            var actualCachedObject = cacheManager.GetObjectFromCache(expectedCacheObject.GetHashCode());

            Assert.AreEqual(expectedCacheObject, actualCachedObject);
        }

        [TestMethod]
        public void GetObjectFromCacheTest()
        {
            var cacheManager = new CacheManager<InvocationResult>();
            
            var expectedCacheObject = new InvocationResult();
            cacheManager.AddObjectToCache(expectedCacheObject);

            var actualCachedObject = cacheManager.GetObjectFromCache(expectedCacheObject.GetHashCode());

            Assert.AreEqual(expectedCacheObject, actualCachedObject);
        }
    }
}
