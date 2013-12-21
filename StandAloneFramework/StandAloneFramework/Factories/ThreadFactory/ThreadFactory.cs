using System;
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

                    methodWrapper.ExecutingThread = new Thread(threadStart);
                    break;

                case ThreadingModel.None:
                    methodWrapper.ExecutingThread = null;
                    break;
            }            
        }
    }
}
