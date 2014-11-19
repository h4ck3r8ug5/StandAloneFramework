// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="MessageHandler.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    /// <summary>
    /// Acts as a central message handler. This would defer all the message displaying functionality to either the front end, or could be used together MSMQ
    /// </summary>
    public class MessageHandler : IMessageHandler
    {
        /// <summary>
        /// Shows the message to a particular consumer - could be a separate message bus or a simple front end such as a Console.
        /// </summary>
        /// <param name="invocationResult">The invocation result.</param>
        public void ShowMessage(InvocationResult invocationResult)
        {
            Console.WriteLine(invocationResult.Message);
        }
    }
}
