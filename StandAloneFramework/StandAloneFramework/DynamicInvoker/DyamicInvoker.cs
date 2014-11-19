// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-18-2014
// ***********************************************************************
// <copyright file="DyamicInvoker.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFramework
{
    /// <summary>
    /// Represents a class that is able to execute a method without knowing the internal workings.
    /// It also wraps the method call in an error handler and defers all error handling the the <c>ErrorManager class</c>
    /// </summary>
    public class DyamicInvoker : ErrorManager, IDynamicInvoker
    {
        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="methodWrapper">The method wrapper.</param>
        /// <returns>InvocationResult.</returns>
        public InvocationResult InvokeMethod(MethodWrapper methodWrapper)
        {
            try
            {
                if (methodWrapper.ExecutingThread.IsObjectNotNull())
                {
                    methodWrapper.ExecutingThread.IsBackground = true;                    
                    //methodWrapper.ExecutingThread.Start();
                    //methodWrapper.ExecutingThread.Join();
                }
                else
                {
                    if (methodWrapper.ActionMethod.IsObjectNotNull())
                    {
                        InvocationResult = methodWrapper.ActionMethod.DynamicInvoke(methodWrapper.Arguments) as InvocationResult;
                    }
                    InvocationResult = methodWrapper.FuncMethod.DynamicInvoke(methodWrapper.Arguments) as InvocationResult;
                }
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, ref invocationResult);
                return InvocationResult;
            }
            return InvocationResult;
        }
    }
}
