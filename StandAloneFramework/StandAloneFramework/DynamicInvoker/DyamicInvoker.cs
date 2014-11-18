using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFramework
{
    public class DyamicInvoker : ErrorManager, IDynamicInvoker
    {
        public InvocationResult InvokeMethod(MethodWrapper methodWrapper)
        {
            try
            {
                if (methodWrapper.ExecutingThread.IsObjectNotNull())
                {
                    methodWrapper.ExecutingThread.IsBackground = true;                    
                    //methodWrapper.ExecutingThread.Start();
                    //methodWrapper.ExecutingThread.Join();
                }
                else
                {
                    if (methodWrapper.ActionMethod.IsObjectNotNull())
                    {
                        InvocationResult = methodWrapper.ActionMethod.DynamicInvoke(methodWrapper.Arguments) as InvocationResult;
                    }
                    InvocationResult = methodWrapper.FuncMethod.DynamicInvoke(methodWrapper.Arguments) as InvocationResult;
                }
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, ref invocationResult);
                return InvocationResult;
            }
            return InvocationResult;
        }
    }
}
