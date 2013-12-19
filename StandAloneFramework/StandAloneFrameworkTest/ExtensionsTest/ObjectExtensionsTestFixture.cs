using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.Extensions;

namespace StandAloneFrameworkTest.ExtensionsTest
{
    [TestClass]
    public class ObjectExtensionsTestFixture
    {
        [TestMethod]
        public void IsObjectNotNullTest()
        {
            var testObject = new object();

            const bool expectedResult = true;

            var actualResult = testObject.IsObjectNotNull();

            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void IsObjectNullTest()
        {
            object testObject = null;

            const bool expectedResult = true;

            var actualResult = testObject.IsObjectNull();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
