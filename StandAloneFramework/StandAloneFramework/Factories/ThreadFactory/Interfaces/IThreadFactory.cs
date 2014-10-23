using System.Collections.Generic;
using System.Threading;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework.Factories.Interfaces
{
    public interface IThreadFactory
    {
        void CreateThread(MethodWrapper threadingModel);
        IList<Thread> RunningThreads { get; set; }
        Thread FindThread(int threadId);
    }
}
