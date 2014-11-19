// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-19-2014
// ***********************************************************************
// <copyright file="ErrorManager.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    /// <summary>
    /// Acts as the central error handling component during method execution.
    /// </summary>
    public class ErrorManager : MessageHandler, IErrorManager
    {
        /// <summary>
        /// The invocation result that is returned by reference after the method execution
        /// </summary>
        protected InvocationResult invocationResult;

        /// <summary>
        /// Gets or sets the invocation result that is returned to the callee after method execution.
        /// </summary>
        /// <value>The invocation result.</value>
        protected InvocationResult InvocationResult
        {
            get { return invocationResult; }
            set { invocationResult = value; }
        }

        /// <summary>
        /// Recursively finds the last exception in an exception that has a single inner or multiple exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Exception.</returns>
        Exception FindLastException(Exception exception)
        {
            if (exception.InnerException.IsObjectNotNull())
            {
                return FindLastException(exception.InnerException);
            }
            return exception;
        }

        #region Implementation of IErrorManager

        /// <summary>
        /// Handles the error messages that are encountered during the method execution.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="invocationResult">The invocation result.</param>
        public void HandleErrorMessages(Exception exception, ref InvocationResult invocationResult)
        {
            var finalException = FindLastException(exception);

            var message = new InvocationResult
            {
                Message = finalException.Message,
                MessageType = InvocationResult.InvocationResultType.Error
            };

            ShowMessage(message);

            invocationResult = message;
        }

        #endregion
    }
}
