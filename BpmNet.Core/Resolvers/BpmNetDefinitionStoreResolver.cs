using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace BpmNet.Core
{
    public class BpmNetDefinitionStoreResolver : IBpmNetStoreResolver
    {
        private readonly IServiceProvider _provider;

        public BpmNetDefinitionStoreResolver(IServiceProvider provider)
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
            where TDefinition : class
        {
            var store = _provider.GetService<IBpmNetDefinitionStore<TDefinition>>();
            if (store == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No definition store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetDefinitionStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().AddDefinitionStore()' to add it to the DI container.")
                    .ToString());
            }
            return store;
        }


        public IBpmNetProcessStore<TProcess> GetProcessStore<TProcess>()
            where TProcess : class
        {
            var store = _provider.GetService<IBpmNetProcessStore<TProcess>>();
            if (store == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No process store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetProcessStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().AddProcessStore()' to add it to the DI container.")
                    .ToString());
            }
            return store;
        }
    }
}
