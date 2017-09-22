using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessFlowStore<TKey, TEntity> :
        IStore<TEntity>, IFindById<TKey, TEntity>, IDisposable
    {

    }
}
