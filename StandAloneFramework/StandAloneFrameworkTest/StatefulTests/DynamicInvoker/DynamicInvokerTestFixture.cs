using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework.Extensions;
using StandAloneFramework.FrameworkClasses;
using StandAloneFrameworkTest.StatefulTests.FauxClasses;

namespace StandAloneFrameworkTest.StatefulTests.DynamicInvoker
{
    [TestClass]
    public class DynamicInvokerTestFixture : FauxDynamicInvoker
    {
        [TestMethod]
        public void CanCallInvokeActionMethod()
        {
            InvokeMethod(new Action<object>(DummyActionMethod));

            ActualFauxCallResult = IsMethodIvoked;

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }

        [TestMethod]
        public void CanCallInvokeFuncMethod()
        {
            ActualFauxCallResult = InvokeMethod(new Func<object, InvocationResult>(DummyFuncMethod)).CallResult();

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }
    }
}
