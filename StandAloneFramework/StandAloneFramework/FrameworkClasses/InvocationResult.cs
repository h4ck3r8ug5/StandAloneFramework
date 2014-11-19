// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-19-2014
// ***********************************************************************
// <copyright file="InvocationResult.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace StandAloneFramework.FrameworkClasses
{
    /// <summary>
    /// Encapsulates the return values of the method execution. The return values could contain contain any error messages, data that is returned from the method execution
    /// </summary>
    public class InvocationResult : MemoryManager<InvocationResult>
    {
        /// <summary>
        /// Represents the execution result type
        /// </summary>
        public enum InvocationResultType
        {
            /// <summary>
            /// An error occurred during method execution
            /// </summary>
            Error,
            /// <summary>
            /// No errors occurred during method execution
            /// </summary>
            Success
        }

        /// <summary>
        /// Gets or sets the friendly error message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public InvocationResultType MessageType { get; set; }
        
        /// <summary>
        /// Gets or sets the data that is returned from the method execution.
        /// </summary>
        /// <value>The data.</value>
        public object Data { get; set; }
    }
}
