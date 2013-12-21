using System;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFrameworkTest.StatefulTests.FauxClasses
{
    public class FauxDynamicInvoker : FauxManager, IDynamicInvoker
    {
        public void InvokeMethod<T>(MethodWrapper methodWrapper)
        {
            IsMethodIvoked = true;            
        }
       
        protected void DummyActionMethod(object args)
        {
            
        }
        protected InvocationResult DummyFuncMethod(object args)
        {
            return null;
        }

        public InvocationResult InvokeMethod(MethodWrapper methodWrapper)
        {
            IsMethodIvoked = true;
            return new InvocationResult();
        }
    }
}
