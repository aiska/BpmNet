using BpmNet.Model;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Stores
{
    public interface IBpmNetProcessInstanceStore<TInstance, TInstanceFlow> : IStore<Guid, TInstance>
        where TInstance : class, IProcessInstance<TInstanceFlow>
        where TInstanceFlow : class, IBpmNetInstanceFlow
    {
        Task<TInstance> GetInstanceAsync(Guid instanceId);
        TInstanceFlow GetOrAddInstanceFlow(TInstance instance, string flowId);
        Task<TInstanceFlow> GetOrAddInstanceFlowAsync(TInstance instance, string flowId);
        Task AddAsync(TInstance instance);
        Task SaveChangesAsync();
        Task<ImmutableArray<TResult>> ListAsync<TResult>(Func<IQueryable<TInstance>, IQueryable<TResult>> query, CancellationToken cancellationToken);
        void AddInstanceFlow(TInstanceFlow instanceFlow);
    }
}
