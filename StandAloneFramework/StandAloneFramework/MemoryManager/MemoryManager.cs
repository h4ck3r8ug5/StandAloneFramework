// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="MemoryManager.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    /// <summary>
    /// Represents the memory manager that active manages the lifetime of any object that derives from it
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MemoryManager<T> : IMemoryManager, IDisposable
    {      
        private T component;
        
        private bool disposed;

        /// <summary>
        /// Gets or sets a value indicating whether this instance of the object disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is object disposed; otherwise, <c>false</c>.</value>
        public bool IsObjectDisposed { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void DisposeObject(object instance)
        {
            instance.Dispose();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Note disposing has been done.
                disposed = true;

                IsObjectDisposed = true;

            }
        }
    }
}
