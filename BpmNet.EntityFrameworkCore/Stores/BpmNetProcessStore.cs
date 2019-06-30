using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
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
    }
}
