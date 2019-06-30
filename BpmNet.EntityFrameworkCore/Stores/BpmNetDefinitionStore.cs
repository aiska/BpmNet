using BpmNet.Bpmn;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.EntityFrameworkCore.Stores
{
    public class BpmNetDefinitionStore<TContext, TDefinition> : BaseStore<TContext, string, TDefinition>, IBpmNetDefinitionStore<TDefinition>
        where TContext : DbContext
        where TDefinition : class, IBpmNetDefinition, new()
    {
        public BpmNetDefinitionStore(
            TContext context,
            IMemoryCache cache,
            IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> options) : base(context)
        {
            _cache = cache;
            Options = options;
        }

        private readonly IMemoryCache _cache;
        private const string DefinitionPrefix = "Def_";
        private const string ProcessPrefix = "Proc_";

        /// <summary>
        /// Gets the options associated with the current store.
        /// </summary>
        protected IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> Options { get; }

        /// <summary>
        /// Gets the database set corresponding to the <typeparamref name="BpmNetDefinition"/> entity.
        /// </summary>
        private DbSet<TDefinition> Definitions => Context.Set<TDefinition>();

        /// <summary>
        /// Determines the number of definitions that exist in the database.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns the number of applications in the database.
        /// </returns>
        public virtual Task<long> CountAsync(CancellationToken cancellationToken)
            => Definitions.LongCountAsync();

        /// <summary>
        /// Determines the number of definitions that match the specified query.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns the number of definitions that match the specified query.
        /// </returns>
        public virtual Task<long> CountAsync<TResult>(Func<IQueryable<TDefinition>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query(Definitions).LongCountAsync();
        }


        private static readonly Func<TContext, DateTime, AsyncEnumerable<TDefinition>> GetLatestDefinitionCompiled =
            EF.CompileAsyncQuery((TContext context, DateTime lastCheck) =>
                (from definition in context.Set<TDefinition>().AsNoTracking()
                 where definition.TimeStamp > lastCheck
                 select definition));

        public Task<TDefinition[]> GetLatestDefinitionAsync(DateTime lastCheck, CancellationToken cancellationToken)
        {
            return GetLatestDefinitionCompiled(Context, lastCheck).ToArrayAsync(cancellationToken);
        }


        /// <summary>
        /// Exposes a compiled query allowing to retrieve an definition using its id.
        /// </summary>
        //private static readonly Func<TContext, string, Task<TDefinition>> FindById =
        //    EF.CompileAsyncQuery((TContext context, string id) =>
        //        (from definition in context.Set<TDefinition>().AsTracking()
        //         where definition.Id.Equals(id)
        //         select definition).FirstOrDefault());

        /// <summary>
        /// Executes the specified query and returns all the corresponding elements.
        /// </summary>
        /// <param name="count">The number of results to return.</param>
        /// <param name="offset">The number of results to skip.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns all the elements returned when executing the specified query.
        /// </returns>
        public virtual async Task<ImmutableArray<TDefinition>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            var query = Definitions.OrderBy(application => application.Id).AsQueryable();

            if (offset.HasValue)
            {
                query = query.Skip(offset.Value);
            }

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return ImmutableArray.CreateRange(await query.ToListAsync(cancellationToken));
        }


        /// <summary>
        /// Executes the specified query and returns all the corresponding elements.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns all the elements returned when executing the specified query.
        /// </returns>
        public virtual async Task<ImmutableArray<TResult>> ListAsync<TResult>(
            Func<IQueryable<TDefinition>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return ImmutableArray.CreateRange(await query(Definitions.AsTracking()).ToListAsync(cancellationToken));
        }

        public override Task CreateAsync(TDefinition definition, CancellationToken cancellationToken)
        {
            _cache.Set(string.Concat(DefinitionPrefix, definition.Id), definition);
            return base.CreateAsync(definition, cancellationToken);
        }
        public override Task UpdateAsync(TDefinition definition, CancellationToken cancellationToken)
        {
            _cache.Set(string.Concat(DefinitionPrefix, definition.Id), definition);
            return base.UpdateAsync(definition, cancellationToken);
        }

        /// <summary>
        /// Removes an existing definition.
        /// </summary>
        /// <param name="definition">The definition to delete.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation.
        /// </returns>
        public override Task DeleteAsync(TDefinition definition, CancellationToken cancellationToken)
        {
            _cache.Remove(definition.Id);
            return base.DeleteAsync(definition, cancellationToken);
        }

        public Task<string[]> GetXmlLatestAsync(DateTime lastCheck, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BpmnProcess> GetProcessAsync(string processId, CancellationToken cancellationToken)
        {
            return _cache.GetOrCreateAsync(string.Concat(ProcessPrefix, processId), proc =>
            {
                return GetBpmNetProcess(processId).ContinueWith(t =>
                {
                    if (t.Result == null)
                    {
                        return null;
                    }
                    return GetDefinitionAsync(t.Result.ReffId, cancellationToken).ContinueWith(defi =>
                    {
                        return defi.Result.Items.OfType<BpmnProcess>().FirstOrDefault(p => p.Id == processId);
                    });
                }).Unwrap();
            });
        }

        private static readonly Func<TContext, string, Task<BpmNetProcess>> GetXmlAsyncCompiled =
            EF.CompileAsyncQuery((TContext context, string processId) =>
                (context.Set<BpmNetProcess>().AsNoTracking().FirstOrDefault(t => t.Id.Equals(processId))));

        private Task<BpmNetProcess> GetBpmNetProcess(string processId)
        {
            return GetXmlAsyncCompiled(Context, processId);
        }

        public Task<BpmnDefinitions> GetDefinitionAsync(string definitionId, CancellationToken cancellationToken)
        {
            return _cache.GetOrCreateAsync(string.Concat(DefinitionPrefix, definitionId), def =>
            {
                return FindByIdAsync(definitionId, cancellationToken).ContinueWith(t =>
                {
                    return SerializerService.DeserializeFromStringAsync(t.Result.Xml, cancellationToken);
                }).Unwrap();
            });
        }

        public Task SaveDefinitionAsync(BpmnDefinitions bpmn, string content, bool replace, CancellationToken cancellationToken)
        {
            if (bpmn == null)
            {
                throw new ArgumentNullException(nameof(bpmn));
            }

            if (bpmn.Id == null)
            {
                throw new ArgumentNullException(nameof(bpmn.Id));
            }

            TDefinition bpmNet = new TDefinition { Id = bpmn.Id, Xml = content, TimeStamp = DateTime.UtcNow };
            return IsExistsAsync(t => t.Id == bpmn.Id, cancellationToken).ContinueWith((exist) =>
            {
                if (exist.Result)
                {
                    if (!replace)
                    {
                        throw new InvalidOperationException("Definition already exists.");
                    }
                    Context.UpdateRange(GetProcesses(bpmn));
                    UpdateAsync(bpmNet, cancellationToken);
                }
                else
                {
                    Context.AddRange(GetProcesses(bpmn));
                    CreateAsync(bpmNet, cancellationToken);
                }
            }, cancellationToken);
        }

        private IEnumerable<BpmNetProcess> GetProcesses(BpmnDefinitions bpmn)
        {
            foreach (var item in bpmn.Items.OfType<BpmnProcess>())
            {
                _cache.Set(string.Concat(ProcessPrefix, item.Id), item);
                yield return new BpmNetProcess { Id = item.Id, ReffId = bpmn.Id };
            }
        }
    }
}
