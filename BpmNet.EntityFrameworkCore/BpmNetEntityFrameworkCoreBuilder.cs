using BpmNet.Core;
using BpmNet.Core.Model;
using BpmNet.EntityFrameworkCore;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    public class BpmNetEntityFrameworkCoreBuilder
    {
        /// <summary>
        /// Gets the services collection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IServiceCollection Services { get; }


        public BpmNetEntityFrameworkCoreBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public BpmNetEntityFrameworkCoreBuilder Configure(Action<BpmNetEntityFrameworkCoreOptions> configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Services.Configure(configuration);

            return this;
        }

        public BpmNetEntityFrameworkCoreBuilder UseDbContext<TContext>()
            where TContext : DbContext
            => UseDbContext(typeof(TContext));

        public BpmNetEntityFrameworkCoreBuilder UseDbContext(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(DbContext).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DbContextType = type);
        }

        public BpmNetEntityFrameworkCoreBuilder UseCaching()
        {
            return Configure(options => options.EnableCaching = true);
        }

        /// <summary>
        /// Configures BpmNet to use the specified entities, derived
        /// from the default BpmNet Entity Framework Core entities.
        /// </summary>
        /// <returns>The <see cref="BpmNetEntityFrameworkCoreBuilder"/>.</returns>
        public BpmNetEntityFrameworkCoreBuilder ReplaceDefaultEntities<TDefinition, TInstance, TInstanceFlow, THistory>()
            where TDefinition : class, IBpmNetDefinition
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where TInstanceFlow : BpmNetInstanceFlow
            where THistory : BpmNetHistory

        {
            Services.Configure<BpmNetCoreOptions>(options =>
            {
                options.DefaultDefinitionType= typeof(TDefinition);
                options.DefaultProcessInstanceType = typeof(TInstance);
                options.DefaultProcessInstanceFlowType = typeof(TInstanceFlow);
                options.DefaultHistoryFlowType = typeof(THistory);
            });

            return this;
        }
    }
}
