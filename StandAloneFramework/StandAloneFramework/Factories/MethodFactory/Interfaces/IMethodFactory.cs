using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.Factories.ThreadFactory;

namespace StandAloneFramework.Factories.Interfaces
{
    public interface IMethodFactory
    {
        object ExecuteMethod();
        void StartFactory(MethodReturnType methodReturnType, MethodType methodType, ThreadingModel threadingModel, object methodToInvoke, DataWrapper args);
    }
}
