// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 10-22-2014
// ***********************************************************************
// <copyright file="MethodFacade.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.MethodFacade.Interfaces;

namespace StandAloneFramework.MethodFacade
{
    /// <summary>
    /// Represents the facade or entry point of all method calls into the framework
    /// </summary>
    public class MethodFacade : IMethodFacade
    {
        #region Properties

        /// <summary>
        /// Gets or sets the method factory.
        /// </summary>
        /// <value>The method factory.</value>
        public IMethodFactory MethodFactory { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodFacade"/> class.
        /// </summary>
        public MethodFacade()
        {
            MethodFactory = new MethodFactory();
        }
    }
}
