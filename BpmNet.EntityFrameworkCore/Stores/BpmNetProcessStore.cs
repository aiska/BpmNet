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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.EntityFrameworkCore.Stores
{
    public class BpmNetProcessStore<TContext, TProcess> : BaseStore<TContext, string, TProcess>, IBpmNetProcessStore<TProcess>
        where TContext : DbContext
        where TProcess : class, IBpmNetProcess, new()
    {
        private readonly IMemoryCache _cache;
        private const string ProcessPrefix = "Proc_";

        /// <summary>
        /// Gets the options associated with the current store.
        /// </summary>
        protected IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> Options { get; }

        public BpmNetProcessStore(
            TContext context,
            IMemoryCache cache,
            IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> options) : base(context)
        {
            _cache = cache;
            Options = options;
        }

        /// <summary>
        /// Gets the database set corresponding to the <typeparamref name="BpmNetDefinition"/> entity.
        /// </summary>
        private DbSet<TProcess> Processes => Context.Set<TProcess>();

        /// <summary>
        /// Determines the number of Process that exist in the database.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns the number of applications in the database.
        /// </returns>
        public Task<long> CountAsync(CancellationToken cancellationToken) => Processes.LongCountAsync();

        /// <summary>
        /// Determines the number of Processes that match the specified query.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can be used to abort the operation.</param>
        /// <returns>
        /// A <see cref="Task"/> that can be used to monitor the asynchronous operation,
        /// whose result returns the number of definitions that match the specified query.
        /// </returns>
        public Task<long> CountAsync<TResult>(Func<IQueryable<TProcess>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query(Processes).LongCountAsync();
        }

        private static readonly Func<TContext, DateTime, AsyncEnumerable<TProcess>> GetLatestDefinitionCompiled =
            EF.CompileAsyncQuery((TContext context, DateTime lastCheck) =>
                (context.Set<TProcess>().AsNoTracking().Where(t => t.TimeStamp > lastCheck).Select(t => t)));

        public Task<TProcess[]> GetLatestProcessAsync(DateTime lastCheck, CancellationToken cancellationToken)
        {
            return GetLatestDefinitionCompiled(Context, lastCheck).ToArrayAsync(cancellationToken);
        }

        public Task<TProcess> GetProcessAsync(string processId, CancellationToken cancellationToken)
        {
            return _cache.GetOrCreateAsync(string.Concat(ProcessPrefix, processId), def =>
            {
                return FindByIdAsync(processId, cancellationToken);
            });
        }

        public Task SaveProcessAsync(TProcess process, bool replace, CancellationToken cancellationToken)
        {
            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }

            if (process.Id == null)
            {
                throw new ArgumentNullException(nameof(process.Id));
            }

            return IsExistsAsync(t => t.Id == process.Id, cancellationToken).ContinueWith((exist) =>
            {
                process.TimeStamp = DateTime.UtcNow;
                if (exist.Result)
                {
                    if (!replace)
                    {
                        throw new InvalidOperationException("ProcessId \"{0}\" already exists.");
                    }
                    return UpdateAsync(process, cancellationToken);
                }
                else
                {
                    return CreateAsync(process, cancellationToken);
                }
            }, cancellationToken);
        }

        private static readonly Func<TContext, string, AsyncEnumerable<TProcess>> GetIdByDefinition =
            EF.CompileAsyncQuery((TContext context, string definitionId) =>
            context.Set<TProcess>().AsNoTracking().Where(t => t.DefinitionId.Equals(definitionId)).Select(t => t));

        public Task DeleteByDefinitionAsync(string definitionId, CancellationToken cancellationToken)
        {
            return GetIdByDefinition(Context, definitionId).ForEachAsync((process) =>
            {
                DeleteAsync(process);
            }, cancellationToken);
        }

        public Task SaveProcessAsync(BpmnDefinitions bpmn, bool replace, CancellationToken cancellationToken)
        {
            return IsExistsAsync(t => t.DefinitionId == bpmn.Id, cancellationToken).ContinueWith((exist) =>
            {
                if (exist.Result)
                {
                    if (!replace)
                    {
                        throw new InvalidOperationException("Definition already exists.");
                    }
                    DeleteByDefinitionAsync(bpmn.Id, cancellationToken).ContinueWith((a) => SaveByDefinitionAsync(bpmn, cancellationToken), cancellationToken);
                }
                else
                {
                    SaveByDefinitionAsync(bpmn, cancellationToken);
                }
            }, cancellationToken);
        }

        private Task SaveByDefinitionAsync(BpmnDefinitions bpmn, CancellationToken cancellationToken)
        {
            foreach (var item in bpmn.Items.OfType<BpmnProcess>())
            {
                var process = new TProcess
                {
                    Id = item.Id,
                    Name = item.Name,
                    DefinitionId = bpmn.Id,
                    IsExecutable = item.IsExecutable,
                    IsClosed = item.IsClosed
                };
                Context.Add(process);
            }

            try
            {
                return Context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw new BpmNetException(BpmNetConstants.Exceptions.ConcurrencyError, new StringBuilder()
                    .AppendLine("The application was concurrently updated and cannot be persisted in its current state.")
                    .Append("Reload the application from the database and retry the operation.")
                    .ToString(), exception);
            }
        }
    }
}
