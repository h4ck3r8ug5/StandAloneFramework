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
        public IThreadFactory ThreadFactory { get; set; }
        public MethodWrapper MethodWrapper { get; set; }
        private readonly IDynamicInvoker dynamicInvoker;

        public MethodFactory()
        {
            ThreadFactory = new ThreadFactory.ThreadFactory();
            MethodWrapper = new MethodWrapper();
            dynamicInvoker = new DyamicInvoker();
        }
     
        public object ExecuteMethod()
        {
            ThreadFactory.CreateThread(MethodWrapper);

           return dynamicInvoker.InvokeMethod(MethodWrapper);
        }

        public void StartFactory(MethodReturnType methodReturnType, MethodType methodType, ThreadingModel threadingModel, object methodToInvoke, DataWrapper args)
        {            
            MethodWrapper = new MethodWrapper
            {
                Arguments = args,
                MethodReturnType = methodReturnType,
                MethodType = methodType,               
                ThreadingModel = threadingModel,
                ActionMethod = methodToInvoke as Action<DataWrapper>,
                FuncMethod = methodToInvoke as Func<DataWrapper,InvocationResult>,
            };         
        }
    }
}
