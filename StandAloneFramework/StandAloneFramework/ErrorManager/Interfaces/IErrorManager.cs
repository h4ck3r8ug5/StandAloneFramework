using System;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Interfaces
{
    public interface IErrorManager
    {
        InvocationResult HandleErrorMessages(Exception exception);
    }
}
