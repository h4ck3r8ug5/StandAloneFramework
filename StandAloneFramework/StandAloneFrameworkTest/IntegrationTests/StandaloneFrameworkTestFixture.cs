using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneFramework;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.Factories.ThreadFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.MethodFacade;
using StandAloneFrameworkTest.ServiceReference1;

namespace StandAloneFrameworkTest.IntegrationTests
{
    [TestClass]
    public class StandaloneFrameworkTestFixture : IntegrationTestBase
    {
        #region Tests

        [TestInitialize]
        public void InitialiseTest()
        {
            MethodFacade = new MethodFacade();
        }

        [TestMethod]
        public void Test_CanInvokeActionMethod()
        {
            DataWrapper = new DataWrapper
            {
                xValue = 50
            };

            var methodToInvoke = new Action<DataWrapper>(wrapper => TestFixtureMethods.AddNums(wrapper));

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsNull(invocationResult);
        }

        [TestMethod]
        public void Test_CanInvokeFuncMethod()
        {
            DataWrapper = new DataWrapper
            {
                xValue = 200,
                Argument = "Test.txt"
            };

            const int expectedResult = 200;

            var methodToInvoke = new Func<DataWrapper, InvocationResult>(TestFixtureMethods.ReadTextFile);

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Return, MethodType.Func, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var actualResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsNotNull(actualResult);

            Assert.AreEqual(expectedResult, int.Parse(actualResult.Data.ToString()));
        }

        [TestMethod]
        public void Test_CanInvokeActionWriteFileMethod()
        {
            var methodToInvoke = new Action<DataWrapper>(TestFixtureMethods.WriteTextFile);

            DataWrapper = new DataWrapper
            {
                xValue = 100,
                Argument = "Test.txt"
            };

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var actualResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsNull(actualResult);             
        }

        [TestMethod]
        public void Test_CanInvokeActionServiceMethod()
        {
            DataWrapper = new DataWrapper
            {
                Argument = "Charles"
            };

            var methodToInvoke = new Action<DataWrapper>(TestFixtureMethods.WriteDataToDatabase);

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsNull(invocationResult);
        }

        [TestMethod]
        public void Test_CanInvokeFuncServiceMethod()
        {
            DataWrapper = new DataWrapper
            {
                Argument = "Charles"
            };

            var methodToInvoke = new Action(() => TestFixtureMethods.WriteDataToDatabase(DataWrapper));

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            MethodFacade.MethodFactory.ExecuteMethod();

            var funcMethodToInvoke = new Func<DataWrapper, InvocationResult>(TestFixtureMethods.ReadDataFromDatabase);

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Return, MethodType.Func, ThreadingModel.Single, funcMethodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            var expected = new DatabaseRecord
            {
                Name = "Charles",
                Password = "Password"
            };

            Assert.IsNotNull(invocationResult);
            Assert.AreEqual(expected.Name,(invocationResult.Data as DatabaseRecord).Name);
            Assert.AreEqual(expected.Password, (invocationResult.Data as DatabaseRecord).Password);
        }

        [TestMethod]
        public void Test_CanInvokeActionMethodWithErrors()
        {
            var methodToInvoke = new Action(() => TestFixtureMethods.WriteTextFile(null));

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsTrue(invocationResult.MessageType == InvocationResult.InvocationResultType.Error);
        }

        [TestMethod]
        public void Test_CanInvokeActionServiceMethodWithErrors()
        {
            var methodToInvoke = new Action<DataWrapper>(TestFixtureMethods.WriteDataToDatabase);

            MethodFacade.MethodFactory.StartFactory(MethodReturnType.Void, MethodType.Action, ThreadingModel.Single, methodToInvoke, DataWrapper);

            var invocationResult = MethodFacade.MethodFactory.ExecuteMethod() as InvocationResult;

            Assert.IsTrue(invocationResult.MessageType == InvocationResult.InvocationResultType.Error);
        }

        [TestCleanup,Ignore]
        public void DisposeResources()
        {
            
        }

        #endregion
    }
}