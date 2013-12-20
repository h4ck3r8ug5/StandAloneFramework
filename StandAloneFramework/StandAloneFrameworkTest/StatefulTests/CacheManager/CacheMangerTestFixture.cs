using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.Extensions;
using StandAloneFrameworkTest.StatefulTests.FauxClasses;

namespace StandAloneFrameworkTest.StatefulTests.CacheManager
{
    [TestClass]
    public class CacheMangerTestFixture : FauxCacheManager
    {
        [TestMethod]
        public void CanCallGetObjectFromCache()
        {
            ActualFauxCallResult = GetObjectFromCache(0).CallResult();

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }

        [TestMethod]
        public void CanCallAddObjectToCache()
        {
            AddObjectToCache(null);
            ActualFauxCallResult = IsMethodIvoked;

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }

        [TestMethod]
        public void CanCallFlushCache()
        {
            FlushCache();
            ActualFauxCallResult = IsMethodIvoked;

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }
    }
}
