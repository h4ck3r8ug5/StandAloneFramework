// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 10-20-2014
// ***********************************************************************
// <copyright file="IThreadFactory.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework.Factories.Interfaces
{
    /// <summary>
    /// The ThreadFactory contract
    /// </summary>
    public interface IThreadFactory
    {
        /// <summary>
        /// Creates the thread for the current method call.
        /// </summary>
        /// <param name="threadingModel">The threading model.</param>
        void CreateThread(MethodWrapper threadingModel);

        /// <summary>
        /// Gets or sets the running threads in the current method call.
        /// </summary>
        /// <value>The running threads.</value>
        IList<Thread> RunningThreads { get; set; }
        
        /// <summary>
        /// Finds the thread for the specific thread id.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Thread.</returns>
        Thread FindThread(int threadId);
    }
}
