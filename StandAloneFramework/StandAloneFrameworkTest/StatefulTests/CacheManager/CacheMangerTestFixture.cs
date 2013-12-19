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
            ActualFauxCallResult = AddObjectToCache(null).CallResult();

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }

        [TestMethod]
        public void CanCallFlushCache()
        {
            ActualFauxCallResult = FlushCache().CallResult();

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }
    }
}
