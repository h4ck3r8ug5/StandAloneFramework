using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework.Factories.ThreadFactory
{
    public enum ThreadingModel
    {
        Single,
        None,
    }

    public class ThreadFactory : IThreadFactory
    {
        public IList<Thread> RunningThreads { get; set; }
        
        public ThreadFactory()
        {
            RunningThreads = new List<Thread>();
        }
    
        public void CreateThread(MethodWrapper methodWrapper)
        {
            switch (methodWrapper.ThreadingModel)
            {
                case ThreadingModel.Single:
                    ParameterizedThreadStart threadStart;

                    if (methodWrapper.ActionMethod.IsObjectNotNull())
                    {
                        threadStart = dataWrapper => methodWrapper.ActionMethod(methodWrapper.Arguments);
                    }
                    else
                    {
                        threadStart = dataWrapper => methodWrapper.FuncMethod(methodWrapper.Arguments);
                    }

                    //methodWrapper.ExecutingThread = new Thread(threadStart);
                    //RunningThreads.Add(methodWrapper.ExecutingThread);

                    break;

                case ThreadingModel.None:
                    methodWrapper.ExecutingThread = null;
                    break;
            }            
        }

        public Thread FindThread(int threadId)
        {
            var thread = RunningThreads.FirstOrDefault(x => x.ManagedThreadId == threadId);

            CodeContractValidator.ArgumentCannotBeNull(thread,"Managed Thread");

            return thread;
        }
    }
}
