// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-17-2014
// ***********************************************************************
// <copyright file="MethodFactory.cs" company="">
//     Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.ThreadFactory;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Intefaces;

namespace StandAloneFramework.Factories.MethodFactory
{
    /// <summary>
    /// Represents the return type of the method
    /// </summary>
    public enum MethodReturnType
    {
        /// <summary>
        /// Method returns a value
        /// </summary>
        Return,
        /// <summary>
        /// Method returns Void
        /// </summary>
        Void
    }

    /// <summary>
    /// Represents the method type
    /// </summary>
    public enum MethodType
    {
        /// <summary>
        /// Action delegate signature
        /// </summary>
        Action,
        /// <summary>
        /// Func delegate signature
        /// </summary>
        Func
    }

    /// <summary>
    /// Class MethodWrapper
    /// </summary>
    public class MethodWrapper
    {
        /// <summary>
        /// Gets or sets the method return type.
        /// </summary>
        /// <value>The type of the method return.</value>
        public MethodReturnType MethodReturnType { get; set; }

        /// <summary>
        /// Gets or sets the method type
        /// </summary>
        /// <value>The type of the method.</value>
        public MethodType MethodType { get; set; }

        /// <summary>
        /// Gets or sets the type of threading to use during execution.
        /// </summary>
        /// <value>The threading model.</value>
        public ThreadingModel ThreadingModel { get; set; }

        /// <summary>
        /// Gets or sets the arguments that are passed into the method.
        /// </summary>
        /// <value>The arguments.</value>
        public DataWrapper Arguments { get; set; }

        /// <summary>
        /// Gets or sets the executing thread that acts as the container for the method.
        /// </summary>
        /// <value>The executing thread.</value>
        public Thread ExecutingThread { get; set; }

        /// <summary>
        /// Gets or sets the action method.
        /// </summary>
        /// <value>The action method.</value>
        public Action<DataWrapper> ActionMethod { get; set; }

        /// <summary>
        /// Gets or sets the function method.
        /// </summary>
        /// <value>The function method.</value>
        public Func<DataWrapper, InvocationResult> FuncMethod { get; set; }
    }

    /// <summary>
    /// Encapsulates functionality that creates and wraps a method with a thread as well as any arguments that the method requires.
    /// </summary>
    public class MethodFactory : IMethodFactory
    {
        /// <summary>
        /// Gets or sets the thread factory.
        /// </summary>
        /// <value>The thread factory.</value>
        public IThreadFactory ThreadFactory { get; set; }
        
        /// <summary>
        /// Gets or sets the method wrapper.
        /// </summary>
        /// <value>The method wrapper.</value>
        public MethodWrapper MethodWrapper { get; set; }
        
        /// <summary>
        /// The dynamic invoker
        /// </summary>
        private readonly IDynamicInvoker dynamicInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodFactory"/> class.
        /// </summary>
        public MethodFactory()
        {
            ThreadFactory = new ThreadFactory.ThreadFactory();
            MethodWrapper = new MethodWrapper();
            dynamicInvoker = new DyamicInvoker();
        }

        /// <summary>
        /// Executes the method.
        /// </summary>
        /// <returns>An instance of type InvocationResult</returns>
        public object ExecuteMethod()
        {
            ThreadFactory.CreateThread(MethodWrapper);

           return dynamicInvoker.InvokeMethod(MethodWrapper);
        }

        /// <summary>
        /// Starts the factory.
        /// </summary>
        /// <param name="methodReturnType">The method return type.</param>
        /// <param name="methodType">Type of the method.</param>
        /// <param name="threadingModel">The threading model to use during runtime.</param>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="args">The arguments for the method</param>
        public void StartFactory(MethodReturnType methodReturnType, MethodType methodType, ThreadingModel threadingModel, object methodToInvoke, DataWrapper args)
        {
            CodeContractValidator.MethodSignatureTypeMatch(methodReturnType, methodType);

            MethodWrapper = new MethodWrapper
            {
                Arguments = args,
                MethodReturnType = methodReturnType,
                MethodType = methodType,               
                ThreadingModel = threadingModel,
                ActionMethod = methodToInvoke as Action<DataWrapper>,
                FuncMethod = methodToInvoke as Func<DataWrapper, InvocationResult>,
            };         
        }
    }
}
