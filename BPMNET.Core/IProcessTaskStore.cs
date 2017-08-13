using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessTaskStore<TKey, TProcessTask> :
        IStore<TProcessTask>,
        IQueryableStore<TProcessTask>,
        IFindById<TKey, TProcessTask>,
        IDisposable
        where TKey : IEquatable<TKey>
        where TProcessTask : IProcessTask<TKey>
    {
    }
}
