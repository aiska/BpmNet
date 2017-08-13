using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    [DebuggerStepThrough]
    internal static class Check
    {
        internal static void ThrowIfNull(object obj)
        {
            if (obj == null)
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
