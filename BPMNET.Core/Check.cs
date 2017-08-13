using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static void ThrowIfNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(obj.GetType().Name);
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
