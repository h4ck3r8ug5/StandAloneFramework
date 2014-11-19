using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFrameworkTest.IntegrationTests.MemoryManager
{
    [TestClass]
    public class MemoryManagerTestFixture
    {
        [TestMethod]
        public void Test_CanDisposeOfObjectCleanly()
        {
            var invocationResult = new InvocationResult();

            using (invocationResult)
            {
                var methodToInvoke = new Action(() => TestFixtureMethods.AddNums(null));
            }

            Assert.IsTrue(invocationResult.IsObjectDisposed);

            invocationResult = new InvocationResult();
            invocationResult.Dispose();
            Assert.IsTrue(invocationResult.IsObjectDisposed);

            invocationResult = new InvocationResult();
            invocationResult.DisposeObject(invocationResult);
            Assert.IsTrue(invocationResult.IsObjectDisposed);

        }
    }
}
