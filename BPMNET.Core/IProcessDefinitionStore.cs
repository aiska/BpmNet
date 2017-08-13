using System;

namespace BPMNET.Core
{
    public interface IProcessDefinitionStore<TKey, TProcessDefinition> :
        IStore<TProcessDefinition>,
        IQueryableStore<TProcessDefinition>,
        IFindById<TKey, TProcessDefinition>,
        IDisposable
        where TProcessDefinition : IProcessDefinition<TKey>
    {
    }
}
