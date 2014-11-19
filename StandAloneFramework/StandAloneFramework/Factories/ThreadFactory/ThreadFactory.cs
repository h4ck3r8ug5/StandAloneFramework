// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-11-2014
// ***********************************************************************
// <copyright file="ThreadFactory.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework.Factories.ThreadFactory
{
    /// <summary>
    /// Represents the threading model to use for the method execution
    /// </summary>
    public enum ThreadingModel
    {
        /// <summary>
        /// The single thread. This would be for an asynchronous operation
        /// </summary>
        Single,
        /// <summary>
        /// None. This would be for a synchronous operation
        /// </summary>
        None,
    }

    /// <summary>
    /// Represents a factory that creates, terminates and handles any thread related tasks for the current method execution
    /// </summary>
    public class ThreadFactory : IThreadFactory
    {
        /// <summary>
        /// Gets or sets the running threads in the current method call.
        /// </summary>
        /// <value>The running threads.</value>
        public IList<Thread> RunningThreads { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadFactory"/> class.
        /// </summary>
        public ThreadFactory()
        {
            RunningThreads = new List<Thread>();
        }

        /// <summary>
        /// Creates the thread.
        /// </summary>
        /// <param name="methodWrapper">The method wrapper.</param>
        public void CreateThread(MethodWrapper methodWrapper)
        {
            switch (methodWrapper.ThreadingModel)
            {
                case ThreadingModel.Single:
                    ParameterizedThreadStart threadStart;

                    if (methodWrapper.ActionMethod.IsObjectNotNull())
                    {
                        threadStart = dataWrapper => methodWrapper.ActionMethod(methodWrapper.Arguments);
                    }
                    else
                    {
                        threadStart = dataWrapper => methodWrapper.FuncMethod(methodWrapper.Arguments);
                    }

                    //methodWrapper.ExecutingThread = new Thread(threadStart);
                    //RunningThreads.Add(methodWrapper.ExecutingThread);

                    break;

                case ThreadingModel.None:
                    methodWrapper.ExecutingThread = null;
                    break;
            }            
        }

        /// <summary>
        /// Finds the thread for the specific thread id.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Thread.</returns>
        public Thread FindThread(int threadId)
        {
            var thread = RunningThreads.FirstOrDefault(x => x.ManagedThreadId == threadId);

            CodeContractValidator.ArgumentCannotBeNull(thread,"Managed Thread");

            return thread;
        }
    }
}
