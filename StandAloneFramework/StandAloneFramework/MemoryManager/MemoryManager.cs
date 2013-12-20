using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    public class MemoryManager<T> : IMemoryManager, IDisposable
    {
        private T component;
        
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void DisposeObject(object instance)
        {
            instance.Dispose();
        }

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

            }
        }
    }
}
