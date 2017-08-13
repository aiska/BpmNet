using System;
using System.Diagnostics;

namespace BPMNET.Bpmn
{
    [DebuggerStepThrough]
    internal static class Check
    {
        internal static void ThrowIfNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(obj.GetType().Name);
            }
        }

        internal static void ThrowIfNull(this Guid obj)
        {
            if (obj == null || obj == default(Guid))
            {
                throw new ArgumentNullException(obj.GetType().Name);
            }
        }

        internal static void ThrowIfDisposed(this IDisposable obj, bool disposed)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(obj.GetType().Name);
            }
        }
    }
}
