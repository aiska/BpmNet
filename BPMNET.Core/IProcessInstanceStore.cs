using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessInstanceStore<TKey, TProcessInstance> : 
        IStore<TProcessInstance>,
        IQueryableStore<TProcessInstance>,
        IFindById<TKey, TProcessInstance>,
        IDisposable
        where TKey : IEquatable<TKey>
        where TProcessInstance : IProcessInstance<TKey>
    {
        Task<TProcessInstance> FindByProcessInstanceNameAsync(string ProcessInstanceName);
        TProcessInstance FindByProcessInstanceName(string ProcessInstanceName);
    }
}
