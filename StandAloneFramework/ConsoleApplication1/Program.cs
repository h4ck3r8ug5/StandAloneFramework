using System;
using System.Runtime.InteropServices.WindowsRuntime;
using StandAloneFramework;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.Factories.ThreadFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.MethodFacade;

namespace ConsoleApplication1
{
    class Program
    {       
        static void Main()
        {            
            var actionHandler = new MethodFacade();

            var methodToInvoke = new Func<DataWrapper, InvocationResult>(AddNums);
            var dataWrapper = new DataWrapper
            {
                xValue = 5,
            };

            actionHandler.MethodFactory.StartFactory(MethodReturnType.Return, MethodType.Func, ThreadingModel.Single, methodToInvoke, dataWrapper);
            var result = actionHandler.MethodFactory.ExecuteMethod() as InvocationResult;

            //TODO: I need to create a thread manager to collect all running threads and check which ones must stop in order to show the input to the front end

            Console.Write(result.Data);
            Console.Read();
        }

        static InvocationResult AddNums(DataWrapper args)
        {
            return new InvocationResult
            {
                Data = (args.xValue + 1).ToString()
            };
        }
    }
}
