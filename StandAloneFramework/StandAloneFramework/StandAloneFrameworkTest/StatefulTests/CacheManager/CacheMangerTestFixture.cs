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
            var expectedObject = new Person();

            var cacheManager = new CacheManager<Person>();

            var cachedObject = cacheManager.GetObjectFromCache(expectedObject.GetHashCode());

            Assert.AreNotEqual(expectedObject, cachedObject);

            cacheManager.AddObjectToCache(expectedObject);

            cachedObject = cacheManager.GetObjectFromCache(expectedObject.GetHashCode());

            Assert.AreEqual(expectedObject,cachedObject);
        }
    }

    class Person
    {
        internal string FirstName { get; set; }

        internal int Age { get; set; }
    }
}

