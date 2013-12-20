using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StandAloneFrameworkTest.IntegrationTests.ErrorManager
{
    [TestClass]
    public class ErrorManagerTestFixture : IntegrationTestBase
    {
        [TestMethod,Ignore]
        public void HandleErrorMessagesTest()
        {
            var exception = new FileNotFoundException("File was not found");

            
        }
    }
}
