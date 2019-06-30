using BpmNet.Model;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Services
{
    public interface IBpmNetProcessService
    {
        Task<ImmutableArray<TResult>> ListProcessAsync<TResult>(Func<IQueryable<object>, IQueryable<TResult>> query, CancellationToken cancellationToken);
        Task<ImmutableArray<TResult>> ListProcessInstanceAsync<TResult>(Func<IQueryable<object>, IQueryable<TResult>> query, CancellationToken cancellationToken);
        Task<IProcessInstance> StartProcessAsync(Guid instanceId, CancellationToken cancellationToken);
        Task<IProcessInstance> StartProcessAsync(string processId, string bussinessKey, CancellationToken cancellationToken);
        Task<IProcessInstance> StartProcessAsync(string processId, string bussinessKey, string tenantId, CancellationToken cancellationToken);
    }
}
