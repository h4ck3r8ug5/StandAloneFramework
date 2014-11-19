// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-18-2014
// ***********************************************************************
// <copyright file="IErrorManager.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Interfaces
{
    /// <summary>
    /// The ErrorManager contract
    /// </summary>
    public interface IErrorManager
    {
        /// <summary>
        /// Handles the error messages that are encountered during the method execution.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="invocationResult">The invocation result.</param>
        void HandleErrorMessages(Exception exception, ref InvocationResult invocationResult);
    }
}
