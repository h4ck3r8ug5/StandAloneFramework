using System;

namespace StandAloneFramework.Interfaces
{
    public interface IErrorManager
    {
        void HandleErrorMessages(Exception exception);
    }
}
