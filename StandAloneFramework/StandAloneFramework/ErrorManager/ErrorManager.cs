using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    public class ErrorManager : MessageHandler, IErrorManager
    {
        protected InvocationResult invocationResult;

        protected InvocationResult InvocationResult
        {
            get { return invocationResult; }
            set { invocationResult = value; }
        }

        public void HandleErrorMessages(Exception exception, ref InvocationResult invocationResult)
        {
            var finalException = FindLastException(exception);

            var message = new  InvocationResult
            {
                Message = finalException.Message,
                MessageType = InvocationResult.InvocationResultType.Error
            };

            ShowMessage(message);

            invocationResult = message;
        }

        Exception FindLastException(Exception exception)
        {
            if (exception.InnerException.IsObjectNotNull())
            {
                return FindLastException(exception.InnerException);
            }
            return exception;
        }        
    }
}
