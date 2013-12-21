using System;
using System.Threading;
using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.ThreadFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFramework.Factories.MethodFactory
{
    public enum MethodReturnType
    {
        Return,
        Void
    }

    public enum MethodType
    {
        Action,
        Func
    }

    public class MethodWrapper
    {       
        public MethodReturnType MethodReturnType { get; set; }

        public MethodType MethodType { get; set; }

        public ThreadingModel ThreadingModel { get; set; }

        public DataWrapper Arguments { get; set; }

        public Thread ExecutingThread { get; set; }

        public Action<DataWrapper> ActionMethod { get; set; }
        
        public Func<DataWrapper,InvocationResult> FuncMethod { get; set; }
    }

    public class MethodFactory : IMethodFactory
    {
        private readonly IThreadFactory threadFactory;
        private MethodWrapper methodWrapper;
        private readonly IDynamicInvoker dynamicInvoker;

        public MethodFactory()
        {
            threadFactory = new ThreadFactory.ThreadFactory();
            methodWrapper = new MethodWrapper();
            dynamicInvoker = new DyamicInvoker();
        }
     
        public object ExecuteMethod()
        {
            threadFactory.CreateThread(methodWrapper);

           return dynamicInvoker.InvokeMethod(methodWrapper);
        }

        public void StartFactory(MethodReturnType methodReturnType, MethodType methodType, ThreadingModel threadingModel, object methodToInvoke, DataWrapper args)
        {            
            methodWrapper = new MethodWrapper
            {
                Arguments = args,
                MethodReturnType = methodReturnType,
                MethodType = methodType,               
                ThreadingModel = threadingModel,
                ActionMethod = methodToInvoke as Action<DataWrapper>,
                FuncMethod = methodToInvoke as Func<DataWrapper,InvocationResult>
            };         
        }
    }
}
