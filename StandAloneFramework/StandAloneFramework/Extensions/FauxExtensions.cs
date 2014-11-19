// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="FauxExtensions.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace StandAloneFramework.Extensions
{
    /// <summary>
    /// Represents a collection of extensions that are used during unit tests
    /// </summary>
    public static class FauxExtensions
    {
        /// <summary>
        /// Calls the result.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>dynamic.</returns>
        public static dynamic CallResult(this object target)
        {
            return target.IsObjectNotNull();
        }
    }
}
