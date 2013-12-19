using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.Extensions;

namespace StandAloneFrameworkTest.ExtensionsTest
{
    [TestClass]
    public class StringExtensionsTestFixture
    {
        [TestMethod]
        public void GetStringEncodingTest()
        {
            const string  testString = "Hello World";

            var bytes = Encoding.ASCII.GetBytes(testString);

            var expectedEncoding = Encoding.UTF8;

            var actualEncoding = Encoding.UTF8.GetString(bytes).GetStringEncoding();          

            Assert.AreEqual(expectedEncoding,actualEncoding);
        }

        [TestMethod,Ignore]
        public void ConvertToEncodingTypeTest()
        {
            const string testString = "Hello World";
            var bytes = Encoding.UTF8.GetBytes(testString);

            var expectedEncoding = Encoding.ASCII.GetString(bytes);

            var actualEncoding = testString.ConvertToEncodingType(Encoding.ASCII);

            Assert.AreEqual(expectedEncoding,actualEncoding);
        }
    }
}
