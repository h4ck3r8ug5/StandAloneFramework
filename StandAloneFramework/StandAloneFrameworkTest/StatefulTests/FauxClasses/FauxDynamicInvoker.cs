using System;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFrameworkTest.StatefulTests.FauxClasses
{
    public class FauxDynamicInvoker : FauxManager, IDynamicInvoker
    {
        public void InvokeMethod<T>(Action<T> methodToInvoke, params object[] args)
        {
            IsMethodIvoked = true;            
        }

        public InvocationResult InvokeMethod<T>(Func<T, InvocationResult> methodToInvoke, params object[] args)
        {
            IsMethodIvoked = true;
            return new InvocationResult();
        }

        protected void DummyActionMethod(object args)
        {
            
        }
        protected InvocationResult DummyFuncMethod(object args)
        {
            return null;
        }
    }
}
