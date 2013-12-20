using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFrameworkTest.IntegrationTests.MemoryManager
{
    [TestClass]
    public class MemoryManagerTestFixture
    {
        [TestMethod,Ignore]
        public void DisposeObjectTest()
        {
            var instance = new InvocationResult();

            var memoryManager = new MemoryManager<InvocationResult>();

            memoryManager.DisposeObject(instance);
        }
    }
}
