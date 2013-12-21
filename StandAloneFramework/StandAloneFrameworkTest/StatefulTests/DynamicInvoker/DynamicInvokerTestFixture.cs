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
            InvokeMethod(null);

            ActualFauxCallResult = IsMethodIvoked;

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }

        [TestMethod]
        public void CanCallInvokeFuncMethod()
        {
            ActualFauxCallResult = InvokeMethod(null).CallResult();

            Assert.IsTrue(ExpectedFauxCallResult == ActualFauxCallResult);
        }
    }
}
