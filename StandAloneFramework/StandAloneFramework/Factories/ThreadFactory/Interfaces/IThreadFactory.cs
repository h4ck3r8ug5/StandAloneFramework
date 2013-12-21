using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.Factories.ThreadFactory;

namespace StandAloneFramework.Factories.Interfaces
{
    public interface IThreadFactory
    {
        void CreateThread(MethodWrapper threadingModel);
    }
}
