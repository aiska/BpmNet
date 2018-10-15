using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.EntityFrameworkCore.Stores
{
    public class BpmNetProcessInstanceStore<TContext, TInstance, TInstanceFlow> : BaseStore<TContext, Guid, TInstance>, IBpmNetProcessInstanceStore<TInstance, TInstanceFlow>
        where TContext : DbContext
        where TInstance : class, IProcessInstance<TInstanceFlow>
        where TInstanceFlow : class, IBpmNetInstanceFlow, new()
    {
        private readonly IMemoryCache _cache;
        private readonly BpmNetEntityFrameworkCoreOptions _options;
        //private readonly ConcurrentDictionary<Guid, TInstance> instanceCache;
        //private readonly ConcurrentDictionary<Guid, TInstanceFlow> instanceFlowCache;

        public BpmNetProcessInstanceStore(
            TContext context,
            IMemoryCache cache,
            IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> options
            ) : base(context)
        {
            _cache = cache;
            _options = options.CurrentValue;
            //instanceCache = new ConcurrentDictionary<Guid, TInstance>();
            //instanceFlowCache = new ConcurrentDictionary<Guid, TInstanceFlow>();
        }

        public TInstanceFlow GetOrAddInstanceFlow(TInstance instance, string flowId)
        {
            var instanceFlow = instance.Flows.FirstOrDefault(t => t.FlowId.Equals(flowId));
            if (instanceFlow == null)
            {
                instanceFlow = new TInstanceFlow
                {
                    ProcessInstanceId = instance.Id,
                    FlowId = flowId
                };
                Context.Add(instanceFlow);
                //instance.Flows.Add(instanceFlow);
            }
            return instanceFlow;
        }

        public async Task<TInstanceFlow> GetOrAddInstanceFlowAsync(TInstance instance, string flowId)
        {
            var instanceFlow = instance.Flows.FirstOrDefault(t => t.FlowId.Equals(flowId));
            if (instanceFlow == null)
            {
                instanceFlow = new TInstanceFlow
                {
                    ProcessInstanceId = instance.Id,
                    FlowId = flowId
                };
                await Context.AddAsync(instanceFlow);
            }
            return instanceFlow;
        }

        private static readonly Func<TContext, Guid, Task<TInstance>> GetInstanceCompiled =
            EF.CompileAsyncQuery((TContext context, Guid instanceId) =>
                context.Set<TInstance>().AsTracking()
                .Where(t => t.Id.Equals(instanceId)).FirstOrDefault());
        public Task<TInstance> GetInstanceAsync(Guid instanceId)
        {
            return _cache.GetOrCreateAsync(instanceId, entry =>
            {
                entry.SlidingExpiration = _options.CacheExpiration;
                return GetInstanceCompiled(Context, instanceId).ContinueWith(task =>
                {
                    if (task.Result != null)
                    {
                        foreach (var item in task.Result.Flows)
                        {
                            Context.Attach(item);
                            _cache.Set(item.Id, item);
                        }
                    }
                    return task.Result;
                });
            });
        }

        private static readonly Func<TContext, Guid, Task<TInstanceFlow>> GetInstanceFlowCompiled =
            EF.CompileAsyncQuery((TContext context, Guid instanceFlowId) =>
                context.Set<TInstanceFlow>().AsTracking()
                .Where(t => t.Id.Equals(instanceFlowId)).FirstOrDefault());
        public Task<TInstanceFlow> GetInstanceFlowAsync(Guid instanceFlowId)
        {
            return _cache.GetOrCreateAsync(instanceFlowId, entry =>
            {
                entry.SlidingExpiration = _options.CacheExpiration;
                return GetInstanceFlowCompiled(Context, instanceFlowId);
            });
        }

        public Task AddAsync(TInstance instance)
        {
            _cache.Set(instance.Id, instance);
            return Context.AddAsync(instance);
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public async Task<ImmutableArray<TResult>> ListAsync<TResult>(Func<IQueryable<TInstance>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return ImmutableArray.CreateRange(await query(Entities.AsNoTracking()).ToListAsync(cancellationToken));
        }

        public void AddInstanceFlow(TInstanceFlow instanceFlow)
        {
            Context.Add(instanceFlow);
        }
    }
}
