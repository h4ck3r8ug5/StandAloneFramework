// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 11-17-2014
// ***********************************************************************
// <copyright file="CodeContractValidator.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework
{
    /// <summary>
    /// Acts as a code contract validator. This is needed to ensure that all contracts conditions are met prior to any code execution
    /// </summary>
    public class CodeContractValidator
    {
        /// <summary>
        /// Validates if critical arguments are cannot be null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="objectFriendlyName">Name of the object friendly.</param>
        /// <exception cref="System.Exception"></exception>
        public static void ArgumentCannotBeNull(object argument, string objectFriendlyName)
        {
            if (argument.IsObjectNull())
            {
                throw new Exception(string.Format("Code Contract validation failed: {0} cannot be null",objectFriendlyName));
            }
        }

        /// <summary>
        /// Validates if the method's return type matches the signature
        /// </summary>
        /// <param name="methodReturnType">Return type of the method return.</param>
        /// <param name="methodType">Type of the method.</param>
        /// <exception cref="System.Exception"></exception>
        public static void MethodSignatureTypeMatch(MethodReturnType methodReturnType, MethodType methodType)
        {
            if ((methodReturnType != MethodReturnType.Return && methodType == MethodType.Func) || (methodReturnType != MethodReturnType.Void && methodType == MethodType.Action))
            {
                throw new Exception(string.Format("Code Contract validation failed: Return type does not match delegate signature type"));
            }
        }
    }
}
