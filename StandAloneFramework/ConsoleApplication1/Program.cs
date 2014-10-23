using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

            actionHandler.MethodFactory.StartFactory(MethodReturnType.Return, MethodType.Func, ThreadingModel.Single,methodToInvoke, dataWrapper);

            var result = actionHandler.MethodFactory.ExecuteMethod() as InvocationResult;

            //TODO: I need to create a thread manager to collect all running threads and check which ones must stop in order to show the input to the front end

            //Thread currentExecutingThread = null;

            //if (actionHandler.MethodFactory.ThreadFactory.RunningThreads.Any(x => x.ManagedThreadId == actionHandler.MethodFactory.MethodWrapper.ExecutingThread.ManagedThreadId))
            //{
            //    currentExecutingThread = actionHandler.MethodFactory.ThreadFactory.FindThread(actionHandler.MethodFactory.MethodWrapper.ExecutingThread.ManagedThreadId);
            //}

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
