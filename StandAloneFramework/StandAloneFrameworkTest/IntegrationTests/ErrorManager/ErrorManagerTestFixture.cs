using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.Factories.ThreadFactory;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFrameworkTest.IntegrationTests.ErrorManager
{
    [TestClass]
    public class ErrorManagerTestFixture : IntegrationTestBase
    {
        [TestMethod]
        public void Test_CanInvokeActionMethodWithErrors()
        {
            var methodToInvoke = new Action(() => TestFixtureMethods.WriteTextFile(null));

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsTrue(invocationResult.MessageType == InvocationResult.InvocationResultType.Error);
        }

        [TestMethod, Ignore]
        public void Test_CanInvokeActionServiceMethodWithErrors()
        {
            var methodToInvoke = new Action<DataWrapper>(TestFixtureMethods.WriteDataToDatabase);

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsTrue(invocationResult.MessageType == InvocationResult.InvocationResultType.Error);
        }
    }
}
