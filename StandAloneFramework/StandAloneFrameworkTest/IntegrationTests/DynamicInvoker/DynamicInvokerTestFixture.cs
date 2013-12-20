using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Extensions;

namespace StandAloneFrameworkTest.IntegrationTests.DynamicInvoker
{
    [TestClass]
    public class DynamicInvokerTestFixture
    {
        private object testResult;

        [TestMethod]
        public void InvokeActionMethod()
        {
            var action = new Action<int>(InternalTestActionMethod);

            var dynamicInvoker = new StandAloneFramework.DyamicInvoker();
            dynamicInvoker.InvokeMethod(action, 2);

            Assert.IsTrue((int)testResult == 3);
        }

        [TestMethod]
        public void InvokeFuncMethod()
        {
            var action = new Func<int,InvocationResult>(InternalTestFuncMethod);

            var dynamicInvoker = new StandAloneFramework.DyamicInvoker();
            var invocationResult = dynamicInvoker.InvokeMethod(action, 2);

            Assert.IsTrue(invocationResult.IsObjectNotNull());
        }

        private void InternalTestActionMethod(int args)
        {
            testResult = 1 + args;
        }

        private static InvocationResult InternalTestFuncMethod(int args)
        {
            return new InvocationResult();
        }
    }
}
