using BpmNet;
using BpmNet.Core;
using BpmNet.Core.Services;
using BpmNet.Resolvers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    public class BpmNetCoreBuilder
    {
        /// <summary>
        /// Gets the services collection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IServiceCollection Services { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BpmNetCoreBuilder"/>.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public BpmNetCoreBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Amends the default BpmNet core configuration.
        /// </summary>
        /// <param name="configuration">The delegate used to configure the BpmNet options.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder Configure(Action<BpmNetCoreOptions> configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Services.Configure(configuration);

            return this;
        }

        #region Definition
        /// <summary>
        /// Configures BpmNet to use the specified entity as the default definition entity.
        /// </summary>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultDefinitionEntity<TDefinition>() where TDefinition : class
            => SetDefaultDefinitionEntity(typeof(TDefinition));

        /// <summary>
        /// Configures BpmNet to use the specified entity as the default definition entity.
        /// </summary>
        /// <param name="type">The definition entity type.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultDefinitionEntity(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultDefinitionType = type);
        }
        #endregion

        #region ProcessInstance
        /// <summary>
        /// Configures BpmNet to use the specified entity as the default ProcessInstance.
        /// </summary>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultProcessInstanceTypeEntity<TProcessInstance>() where TProcessInstance : class
            => SetDefaultProcessInstanceTypeEntity(typeof(TProcessInstance));

        /// <summary>
        /// Configures BpmNet to use the specified entity as the default ProcessInstance.
        /// </summary>
        /// <param name="type">The ProcessInstance entity type.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultProcessInstanceTypeEntity(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultProcessInstanceType = type);
        }
        #endregion

        #region InstanceFlow
        /// <summary>
        /// Configures BpmNet to use the specified entity as the default ProcessInstanceFlow.
        /// </summary>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultProcessInstanceFlowTypeEntity<TProcessInstanceFlow>() where TProcessInstanceFlow : class
            => SetDefaultProcessInstanceFlowTypeEntity(typeof(TProcessInstanceFlow));

        /// <summary>
        /// Configures BpmNet to use the specified entity as the default ProcessInstanceFlow.
        /// </summary>
        /// <param name="type">The ProcessInstanceFlow entity type.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultProcessInstanceFlowTypeEntity(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultProcessInstanceFlowType = type);
        }
        #endregion

        #region History
        /// <summary>
        /// Configures BpmNet to use the specified entity as the default DefaultHistoryFlow.
        /// </summary>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultHistoryFlowTypeEntity<TProcessInstance>() where TProcessInstance : class
            => SetDefaultHistoryFlowTypeEntity(typeof(TProcessInstance));

        /// <summary>
        /// Configures BpmNet to use the specified entity as the default DefaultHistoryFlow.
        /// </summary>
        /// <param name="type">The DefaultHistoryFlow entity type.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder SetDefaultHistoryFlowTypeEntity(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultHistoryFlowType = type);
        }
        #endregion

        #region ReplaceStoreResolver
        /// <summary>
        /// Replaces the default definition store resolver by a custom implementation.
        /// </summary>
        /// <typeparam name="TResolver">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder ReplaceStoreResolver<TResolver>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TResolver : IBpmNetStoreResolver
            => ReplaceStoreResolver(typeof(TResolver), lifetime);

        /// <summary>
        /// Replaces the default definition store resolver by a custom implementation.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder ReplaceStoreResolver(Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(IBpmNetStoreResolver).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            Services.Replace(new ServiceDescriptor(typeof(IBpmNetStoreResolver), type, lifetime));

            return this;
        } 
        #endregion

        public BpmNetCoreBuilder ReplaceDefinitionService<TService>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TService : class
            => ReplaceDefinitionService(typeof(TService), lifetime);


        /// <summary>
        /// Replace the default definition service by a custom service derived
        /// from <see cref="BpmNetDefinitionService{TDefinition}"/>.
        /// Note: when using this overload, the definition service can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom service.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public BpmNetCoreBuilder ReplaceDefinitionService(Type type, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = BpmNetCoreHelpers.FindGenericBaseType(type, typeof(BpmNetDefinitionService<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: service can be either open generics (e.g BpmNetDefinitionService<>)
            // or closed generics (e.g BpmNetDefinitionService<BpmNetDefinition>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(new ServiceDescriptor(type, type, lifetime));
                Services.Replace(new ServiceDescriptor(typeof(BpmNetDefinitionService<>), type, lifetime));
            }
            else
            {
                object ResolveService(IServiceProvider provider)
                    => provider.GetRequiredService(typeof(BpmNetDefinitionService<>)
                        .MakeGenericType(root.GenericTypeArguments[0]));

                Services.Replace(new ServiceDescriptor(type, ResolveService, lifetime));
                Services.Replace(new ServiceDescriptor(typeof(BpmNetDefinitionService<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type, lifetime));
            }

            return this;
        }
    }
}
