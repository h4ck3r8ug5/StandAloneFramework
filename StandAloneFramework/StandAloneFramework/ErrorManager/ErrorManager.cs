using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    public class ErrorManager : MessageHandler, IErrorManager
    {
        public InvocationResult HandleErrorMessages(Exception exception)
        {
            var finalException = FindLastException(exception);

            return new InvocationResult
            {
                Message = finalException.Message,
                MessageType = InvocationResult.InvocationResultType.Error
            };
        }


        Exception FindLastException(Exception exception)
        {
            if (exception.InnerException.IsObjectNotNull())
            {
                return FindLastException(exception.InnerException);
            }
            return exception.InnerException;
        }
    }
}
