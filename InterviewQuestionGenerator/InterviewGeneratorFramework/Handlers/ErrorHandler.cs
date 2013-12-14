using System;
using System.IO;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.Extensions;

namespace InterviewGeneratorFramework.Handlers
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Executes the func or action and handles any errors.
        /// </summary>
        /// <param name="callingMethod">The calling method to invoke</param>
        /// <param name="args">The arguments for the calling method</param>
        /// <returns>Tuple containing the SystemMessage and the relevant data.</returns>
        internal static Tuple<SystemMessage, object> ExecuteAndHandleAnyErrors<T,TArg1>(this object callingMethod, params object[] args)
        {
            dynamic methodToExecute;
            var arguments = args;

            if (callingMethod.GetType() == typeof(Func<T, TArg1>))
            {
                methodToExecute = (callingMethod as Func<T,TArg1>);
            }
            else
	        {
                methodToExecute = (callingMethod as Action<T, TArg1>);
            }

            try
            {
                var result = methodToExecute.DynamicInvoke(args);
                return new Tuple<SystemMessage, object>(null, result);
            }
            catch (Exception ex)
            {
                var systemMessage = new SystemMessage();

                var lastInnerException = GetLastInnerException(ex);

                switch (lastInnerException.Message)
                {                  
                    case "Data at the root level is invalid. Line 1, position 1.":
                        systemMessage.MessageReason = SystemMessage.MessageType.XmlInterviewFileIsCorrupt;
                        systemMessage.Arguments = (arguments[0] as DataWrapper).InterviewXmlFile;
                        MessageHandler.ShowMessage(systemMessage);
                        break;
                }
              
                return null;
            }
        }

        private static Exception GetLastInnerException(Exception exception)
        {
            var innerException = exception;
            if (exception.InnerException.IsObjectNotNull())
            {
                innerException = exception.InnerException;
                return GetLastInnerException(innerException);
            }
            return innerException;
        }

        /// <summary>
        /// Executes the func or action and handles any errors.
        /// </summary>
        /// <param name="callingMethod">The calling method to invoke</param>
        /// <param name="args">The arguments for the calling method</param>
        /// <returns>Tuple containing the SystemMessage and the relevant data.</returns>
        internal static Tuple<SystemMessage, object> ExecuteAndHandleAnyErrors<T>(this object callingMethod, params object[] args)
        {
            dynamic methodToExecute;
            var arguments = args;

            if (callingMethod.GetType().DeclaringType == typeof(Func<T>))
            {
                methodToExecute = (callingMethod as Func<T>);
            }
            else
            {
                methodToExecute = (callingMethod as Action<T>);
            }

            try
            {
                var result = methodToExecute.DynamicInvoke(args);
                return new Tuple<SystemMessage, object>(null, result);
            }
            catch (Exception ex)
            {
                var systemMessage = new SystemMessage();

                var lastInnerException = GetLastInnerException(ex);

                if (lastInnerException.GetType() == typeof(FileNotFoundException))
                {
                    systemMessage.MessageReason = SystemMessage.MessageType.InterviewFileDoesNotExist;
                    systemMessage.Arguments = (arguments[0] as DataWrapper).InterviewXmlFile;
                    MessageHandler.ShowMessage(systemMessage);
                    return null;
                }

                switch (lastInnerException.Message)
                {
                    case "Data at the root level is invalid. Line 1, position 1.":
                        systemMessage.MessageReason = SystemMessage.MessageType.XmlInterviewFileIsCorrupt;
                        systemMessage.Arguments = (arguments[0] as DataWrapper).InterviewXmlFile;
                        MessageHandler.ShowMessage(systemMessage);
                        break;
                }

                return null;
            }
        }       
    }
}
