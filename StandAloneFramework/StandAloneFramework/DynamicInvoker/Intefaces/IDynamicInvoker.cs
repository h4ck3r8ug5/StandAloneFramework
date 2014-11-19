// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="IDynamicInvoker.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using StandAloneFramework.Factories.MethodFactory;
 using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Intefaces
 {
     /// <summary>
     /// The DynamicInvokers contract
     /// </summary>
     public interface IDynamicInvoker
     {
         /// <summary>
         /// Invokes the method.
         /// </summary>
         /// <param name="methodWrapper">The method wrapper.</param>
         /// <returns>InvocationResult.</returns>
         InvocationResult InvokeMethod(MethodWrapper methodWrapper);
     }
 }