using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace BpmNet.Core.Resolvers
{
    public class BpmNetStoreResolver : IBpmNetStoreResolver
    {
        private readonly IServiceProvider _provider;

        public BpmNetStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Returns an definition store compatible with the specified definition type or throws an
        /// <see cref="InvalidOperationException"/> if no store can be built using the specified type.
        /// </summary>
        /// <typeparam name="TDefinition">The type of the definition entity.</typeparam>
        /// <returns>An <see cref="IBpmNetDefinitionStore{TDefinition}"/>.</returns>
        public IBpmNetDefinitionStore<TDefinition> GetDefinitionStore<TDefinition>()
            where TDefinition : class, IBpmNetDefinition
        {
            var store = _provider.GetService<IBpmNetDefinitionStore<TDefinition>>();
            if (store == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No definition store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetDefinitionStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().ReplaceDefinitionStore()' to add it to the DI container.")
                    .ToString());
            }
            return store;
        }

        public IBpmNetProcessInstanceStore<TInstance, TInstanceFlow> GetProcessInstanceStore<TInstance, TInstanceFlow>()
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where TInstanceFlow : class, IBpmNetInstanceFlow
        {
            var store = _provider.GetService<IBpmNetProcessInstanceStore<TInstance, TInstanceFlow>>();
            if (store == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No start event store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetProcessStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().ReplaceProcessInstanceStore()' to add it to the DI container.")
                    .ToString());
            }
            return store;
        }

        public IBpmNetHistoryStore<THistory> GetHistoryStore<THistory>() where THistory : class, IBpmNetHistory
        {
            var store = _provider.GetService<IBpmNetHistoryStore<THistory>>();
            if (store == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No History store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetProcessStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().ReplaceHistoryStore()' to add it to the DI container.")
                    .ToString());
            }
            return store;
        }
    }
}
