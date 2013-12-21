using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;
using StandAloneFramework.Factories.MethodFactory;
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
            var action = new Action<DataWrapper>(InternalTestActionMethod);

            var dynamicInvoker = new StandAloneFramework.DyamicInvoker();
            dynamicInvoker.InvokeMethod(new MethodWrapper
            {
                ActionMethod = action,                
            });

            Assert.IsTrue((int)testResult == 3);
        }

        [TestMethod]
        public void InvokeFuncMethod()
        {
            var action = new Func<DataWrapper,InvocationResult>(InternalTestFuncMethod);

            var dynamicInvoker = new DyamicInvoker();
            var invocationResult = dynamicInvoker.InvokeMethod(new MethodWrapper
            {
              FuncMethod  = action
            });

            Assert.IsTrue(invocationResult.IsObjectNotNull());
        }

        private void InternalTestActionMethod(DataWrapper args)
        {
            testResult = 1 + args.xValue;
        }

        private static InvocationResult InternalTestFuncMethod(DataWrapper args)
        {
            return new InvocationResult();
        }
    }
}
