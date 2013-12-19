using System;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFramework
{
    public class DyamicInvoker : ErrorManager, IDynamicInvoker
    {
        public void InvokeMethod<T>(Action<T> methodToInvoke, params object[] args)
        {
            try
            {
                methodToInvoke.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
               HandleErrorMessages(ex);
            }
        }

        public InvocationResult InvokeMethod<T>(Func<T, InvocationResult> methodToInvoke, params object[] args)
        {
            try
            {
                return (InvocationResult) methodToInvoke.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
                return HandleErrorMessages(ex);
            }
        }
    }
}
