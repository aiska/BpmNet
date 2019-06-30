using BpmNet.Core;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.EntityFrameworkCore.Stores;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Text;

namespace BpmNet.EntityFrameworkCore.Resolvers
{
    /// <summary>
    /// Exposes a method allowing to resolve an definition store.
    /// </summary>
    public class BpmNetStoreResolver : IBpmNetStoreResolver
    {
        private static readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();
        private readonly IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> _options;
        private readonly IServiceProvider _provider;

        public BpmNetStoreResolver(
            IOptionsMonitor<BpmNetEntityFrameworkCoreOptions> options,
            IServiceProvider provider)
        {
            _options = options;
            _provider = provider;
        }

        /// <summary>
        /// Returns an definition store compatible with the specified definition type or throws an
        /// <see cref="InvalidOperationException"/> if no store can be built using the specified type.
        /// </summary>
        /// <typeparam name="TDefinition">The type of the Definition entity.</typeparam>
        /// <returns>An <see cref="IBpmNetDefinitionStore{TDefinition}"/>.</returns>
        public IBpmNetDefinitionStore<TDefinition> GetDefinitionStore<TDefinition>()
            where TDefinition : class, IBpmNetDefinition
        {
            var store = _provider.GetService<IBpmNetDefinitionStore<TDefinition>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TDefinition), key =>
            {
                if (!typeof(BpmNetDefinition).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified definition type is not compatible with the Entity Framework Core stores. ")
                        .Append("When enabling the Entity Framework Core stores, make sure your custom entity is inherit From ")
                        .Append("'BpmNetDefinition' in your entity model (from the 'BpmNet.Core' package) ")
                        .ToString());
                }
                var context = _options.CurrentValue.DbContextType;
                if (context == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("No Entity Framework Core context was specified in the BpmNet options.")
                        .Append("To configure the BpmNet Entity Framework Core stores to use a specific 'DbContext', ")
                        .Append("use 'options.UseEntityFrameworkCore().UseDbContext<TContext>()'.")
                        .ToString());
                }

                return typeof(BpmNetDefinitionStore<,>).MakeGenericType(context, key);
            });

            return (IBpmNetDefinitionStore<TDefinition>)_provider.GetRequiredService(type);
        }

        public IBpmNetProcessStore<TProcess> GetProcessStore<TProcess>()
            where TProcess : class, IBpmNetProcess
        {
            var store = _provider.GetService<IBpmNetProcessStore<TProcess>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TProcess), key =>
            {
                if (!typeof(BpmNetProcess).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified TProcess type is not compatible with the Entity Framework Core stores. ")
                        .Append("When enabling the Entity Framework Core stores, make sure your custom entity is inherit From ")
                        .Append("'BpmNetProcess' in your entity model (from the 'BpmNet.Core' package) ")
                        .ToString());
                }

                var context = _options.CurrentValue.DbContextType;
                if (context == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("No Entity Framework Core context was specified in the BpmNet options.")
                        .Append("To configure the BpmNet Entity Framework Core stores to use a specific 'DbContext', ")
                        .Append("use 'options.UseEntityFrameworkCore().UseDbContext<TContext>()'.")
                        .ToString());
                }

                return typeof(BpmNetProcessStore<,>).MakeGenericType(context, key);
            });

            return (IBpmNetProcessStore<TProcess>)_provider.GetRequiredService(type);
        }

        public IBpmNetProcessInstanceStore<TInstance, TInstanceFlow> GetProcessInstanceStore<TInstance, TInstanceFlow>()
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where TInstanceFlow : class, IBpmNetInstanceFlow
        {
            var store = _provider.GetService<IBpmNetProcessInstanceStore<TInstance, TInstanceFlow>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TInstance), key =>
            {
                var root = BpmNetCoreHelpers.FindGenericBaseType(key, typeof(BpmNetProcessInstance<>));
                if (root == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified start event type is not compatible with the Entity Framework Core stores. ")
                        .Append("When enabling the Entity Framework Core stores, make sure your entity is Assignable From ")
                        .Append("'IBpmNetProcess' in your entity model (from the 'BpmNet.Abstractions' package) ")
                        .Append("or a custom entity that inherits from the generic 'BpmNetProcessInstance' entity.")
                        .ToString());
                }
                var context = _options.CurrentValue.DbContextType;
                if (context == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("No Entity Framework Core context was specified in the BpmNet options. ")
                        .Append("To configure the BpmNet Entity Framework Core stores to use a specific 'DbContext', ")
                        .Append("use 'options.UseEntityFrameworkCore().UseDbContext<TContext>()'.")
                        .ToString());
                }

                return typeof(BpmNetProcessInstanceStore<,,>).MakeGenericType(context, key, root.GenericTypeArguments[0]);

            });

            return (IBpmNetProcessInstanceStore<TInstance, TInstanceFlow>)_provider.GetRequiredService(type);
        }

        public IBpmNetHistoryStore<THistory> GetHistoryStore<THistory>() where THistory : class, IBpmNetHistory
        {
            var store = _provider.GetService<IBpmNetHistoryStore<THistory>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(THistory), key =>
            {
                var context = _options.CurrentValue.DbContextType;
                if (context == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("No Entity Framework Core context was specified in the BpmNet options. ")
                        .Append("To configure the BpmNet Entity Framework Core stores to use a specific 'DbContext', ")
                        .Append("use 'options.UseEntityFrameworkCore().UseDbContext<TContext>()'.")
                        .ToString());
                }

                return typeof(BpmNetHistoryStore<,>).MakeGenericType(context, key);
            });

            return (IBpmNetHistoryStore<THistory>)_provider.GetRequiredService(type);
        }
    }
}
