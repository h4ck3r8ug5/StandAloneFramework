using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;

namespace StandAloneFrameworkTest.StatefulTests.CacheManager
{
    [TestClass]
    public class CacheMangerTestFixture
    {
        [TestMethod]
        public void CanGetObjectFromCache()
        {
            var expectedObject = new Object();

            var cacheManager = new CacheManager<Object>();
            cacheManager.AddObjectToCache(expectedObject);

            var cachedObject = cacheManager.GetObjectFromCache(expectedObject.GetHashCode());

            Assert.AreEqual(expectedObject, cachedObject);

        }
    }
}
