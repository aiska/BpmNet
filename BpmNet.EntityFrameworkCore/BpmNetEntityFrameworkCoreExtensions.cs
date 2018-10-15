using BpmNet.Core.Model;
using BpmNet.EntityFrameworkCore;
using BpmNet.EntityFrameworkCore.Configurations;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.EntityFrameworkCore.Resolvers;
using BpmNet.EntityFrameworkCore.Stores;
using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BpmNetEntityFrameworkCoreExtensions
    {
        /// <summary>
        /// Registers the Entity Framework Core stores services in the DI container and
        /// configures BpmNet to use the Entity Framework Core entities by default.
        /// </summary>
        /// <param name="builder">The services builder used by BpmNet to register new services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetEntityFrameworkCoreBuilder"/>.</returns>
        public static BpmNetEntityFrameworkCoreBuilder UseEntityFrameworkCore(this BpmNetCoreBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddMemoryCache();

            builder.SetDefaultDefinitionEntity<BpmNetDefinition>();
            builder.SetDefaultProcessInstanceTypeEntity<BpmNetProcessInstance>();
            builder.SetDefaultProcessInstanceFlowTypeEntity<BpmNetInstanceFlow>();
            builder.SetDefaultHistoryFlowTypeEntity<BpmNetHistory>();

            builder.ReplaceStoreResolver<BpmNetStoreResolver>();

            builder.Services.TryAddScoped(typeof(BpmNetDefinitionStore<,>));
            builder.Services.TryAddScoped(typeof(BpmNetProcessInstanceStore<,,>));
            builder.Services.TryAddScoped(typeof(BpmNetHistoryStore<,>));

            return new BpmNetEntityFrameworkCoreBuilder(builder.Services);
        }

        /// <summary>
        /// Registers the Entity Framework Core stores services in the DI container and
        /// configures BpmNet to use the Entity Framework Core entities by default.
        /// </summary>
        /// <param name="builder">The services builder used by BpmNet to register new services.</param>
        /// <param name="configuration">The configuration delegate used to configure the Entity Framework Core services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public static BpmNetCoreBuilder UseEntityFrameworkCore(this BpmNetCoreBuilder builder, Action<BpmNetEntityFrameworkCoreBuilder> configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(builder.UseEntityFrameworkCore());

            return builder;
        }

        /// <summary>
        /// Registers the BpmNet entity sets in the Entity Framework Core context
        /// using the default BpmNet models.
        /// </summary>
        /// <param name="builder">The builder used to configure the Entity Framework context.</param>
        /// <returns>The Entity Framework context builder.</returns>
        public static DbContextOptionsBuilder UseBpmNet(this DbContextOptionsBuilder builder)
            => builder.UseBpmNet<BpmNetProcessInstance, BpmNetInstanceFlow, BpmNetHistory>();


        /// <summary>
        /// Registers the BpmNet entity sets in the Entity Framework Core
        /// context using the specified entities.
        /// </summary>
        /// <param name="builder">The builder used to configure the Entity Framework context.</param>
        /// <returns>The Entity Framework context builder.</returns>
        public static DbContextOptionsBuilder UseBpmNet<TInstance, TInstanceFlow, THistory>(this DbContextOptionsBuilder builder)
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where THistory : BpmNetHistory
            where TInstanceFlow : BpmNetInstanceFlow
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.ReplaceService<IModelCustomizer, BpmNetEntityFrameworkCoreCustomizer<TInstance, TInstanceFlow, THistory>>();
        }

        /// <summary>
        /// Registers the BpmNet entity sets in the Entity Framework Core context
        /// using the default BpmNet models.
        /// </summary>
        /// <param name="builder">The builder used to configure the Entity Framework context.</param>
        /// <returns>The Entity Framework context builder.</returns>
        public static ModelBuilder UseBpmNet(this ModelBuilder builder) => builder.UseBpmNet<
            BpmNetProcessInstance,
            BpmNetInstanceFlow,
            BpmNetHistory>();

        /// <summary>
        /// Registers the BpmNet entity sets in the Entity Framework Core
        /// context using the specified entities.
        /// </summary>
        /// <param name="builder">The builder used to configure the Entity Framework context.</param>
        /// <returns>The Entity Framework context builder.</returns>
        public static ModelBuilder UseBpmNet<TInstance, TInstanceFlow, THistory>(this ModelBuilder builder)
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where TInstanceFlow : BpmNetInstanceFlow
            where THistory : BpmNetHistory

        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ApplyConfiguration(new BpmNetDefinitionConfiguration());
            builder.ApplyConfiguration(new BpmNetProcessInstanceConfiguration<TInstance, TInstanceFlow>());
            builder.ApplyConfiguration(new BpmNetInstanceFlowConfiguration<TInstanceFlow>());
            builder.ApplyConfiguration(new BpmNetHistoryConfiguration<THistory>());
            builder.ApplyConfiguration(new BpmNetRootConfiguration());
            builder.ApplyConfiguration(new BpmNetProcessConfiguration());
            
            return builder;
        }
    }
}
