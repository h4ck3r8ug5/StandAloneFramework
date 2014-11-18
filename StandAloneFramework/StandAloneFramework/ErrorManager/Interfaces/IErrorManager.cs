using System;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Interfaces
{
    public interface IErrorManager
    {
        void HandleErrorMessages(Exception exception, ref InvocationResult invocationResult);
    }
}
