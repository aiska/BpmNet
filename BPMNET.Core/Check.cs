using System;
using System.Diagnostics;

namespace BPMNET.Core
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static void ThrowIfNull(this object obj)
        {
            obj.ThrowIfNull(obj.GetType().Name);
        }

        public static void ThrowIfNull(this object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, string.Format("Parameter '{0}' is null", name));
            }
        }

        public static void ThrowIfNull(this object obj, Exception exception)
        {
            if (obj == null)
            {
                throw exception;
            }
        }

        public static void ThrowIfDisposed(this IDisposable obj, bool disposed)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(obj.GetType().Name);
            }
        }
    }
}
