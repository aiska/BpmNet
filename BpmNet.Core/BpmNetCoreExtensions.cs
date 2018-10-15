using BpmNet;
using BpmNet.Abstractions.Flow;
using BpmNet.Core;
using BpmNet.Core.FlowService;
using BpmNet.Core.Model;
using BpmNet.Core.Resolvers;
using BpmNet.Core.Services;
using BpmNet.Resolvers;
using BpmNet.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Exposes extensions allowing to register the BpmNet core services.
    /// </summary>
    public static class BpmNetCoreExtensions
    {

        /// <summary>
        /// Registers the BpmNet core services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by BpmNet to register new services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetCoreBuilder"/>.</returns>
        public static BpmNetCoreBuilder AddCore(this BpmNetBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddLogging();
            builder.Services.AddOptions();

            builder.Services.TryAddScoped(typeof(ProcessFlowService<,,>));
            builder.Services.TryAddScoped(typeof(BpmNetDefinitionService<>));

            builder.Services.TryAddScoped<IBpmNetStoreResolver, BpmNetStoreResolver>();
            builder.Services.TryAddScoped<IBpmNetSerializerService, BpmNetSerializerService>();
            builder.Services.TryAddScoped<IBpmNetSequenceFlowProcessService, BpmNetSequenceFlowProcessService>();
            builder.Services.TryAddScoped<IBpmNetStartEventProcessService, BpmNetStartEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetUserTaskProcessService, BpmNetUserTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetExclusiveGatewayProcessService, BpmNetExclusiveGatewayProcessService>();
            builder.Services.TryAddScoped<IBpmNetInclusiveGatewayProcessService, BpmNetInclusiveGatewayProcessService>();
            builder.Services.TryAddScoped<IBpmNetParallelGatewayProcessService, BpmNetParallelGatewayProcessService>();
            builder.Services.TryAddScoped<IBpmNetServiceTaskProcessService, BpmNetServiceTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetEndEventProcessService, BpmNetEndEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetFlowElementProcessService, BpmNetFlowElementProcessService>();
            builder.Services.TryAddScoped<IBpmNetAdHocSubProcessService, BpmNetAdHocSubProcessService>();
            builder.Services.TryAddScoped<IBpmNetBoundaryEventProcessService, BpmNetBoundaryEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetBusinessRuleTaskProcessService, BpmNetBusinessRuleTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetCallActivityProcessService, BpmNetCallActivityProcessService>();
            builder.Services.TryAddScoped<IBpmNetCallChoreographyProcessService, BpmNetCallChoreographyProcessService>();
            builder.Services.TryAddScoped<IBpmNetChoreographyTaskProcessService, BpmNetChoreographyTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetComplexGatewayProcessService, BpmNetComplexGatewayProcessService>();
            builder.Services.TryAddScoped<IBpmNetSendTaskProcessService, BpmNetSendTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetManualTaskProcessService, BpmNetManualTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetScriptTaskProcessService, BpmNetScriptTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetSubProcessProcessService, BpmNetSubProcessProcessService>();
            builder.Services.TryAddScoped<IBpmNetTaskProcessService, BpmNetTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetReceiveTaskProcessService, BpmNetReceiveTaskProcessService>();
            builder.Services.TryAddScoped<IBpmNetDataObjectProcessService, BpmNetDataObjectProcessService>();
            builder.Services.TryAddScoped<IBpmNetDataObjectReferenceProcessService, BpmNetDataObjectReferenceProcessService>();
            builder.Services.TryAddScoped<IBpmNetDataStoreReferenceProcessService, BpmNetDataStoreReferenceProcessService>();
            builder.Services.TryAddScoped<IBpmNetEventBasedGatewayProcessService, BpmNetEventBasedGatewayProcessService>();
            builder.Services.TryAddScoped<IBpmNetImplicitThrowEventProcessService, BpmNetImplicitThrowEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetIntermediateCatchEventProcessService, BpmNetIntermediateCatchEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetIntermediateThrowEventProcessService, BpmNetIntermediateThrowEventProcessService>();
            builder.Services.TryAddScoped<IBpmNetSubChoreographyProcessService, BpmNetSubChoreographyProcessService>();
            builder.Services.TryAddScoped<IBpmNetTransactionProcessService, BpmNetTransactionProcessService>();
            builder.Services.TryAddScoped<IBpmNetEventProcessService, BpmNetEventProcessService>();

            builder.Services.TryAddScoped(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;
                if (options.DefaultDefinitionType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default entity type was configured in the BpmNet core options, ")
                        .AppendLine("which generally indicates that one or more store was not registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IBpmNetDefinitionService)provider.GetRequiredService(
                    typeof(BpmNetDefinitionService<>).MakeGenericType(
                        options.DefaultDefinitionType
                    ));
            });
            builder.Services.TryAddScoped(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;
                if (options.DefaultProcessInstanceType == null ||
                    options.DefaultDefinitionType == null ||
                    options.DefaultProcessInstanceFlowType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default entity type was configured in the BpmNet core options, ")
                        .AppendLine("which generally indicates that one or more store was not registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IProcessFlowService)provider.GetRequiredService(
                    typeof(ProcessFlowService<,,>).MakeGenericType(
                        options.DefaultDefinitionType,
                        options.DefaultProcessInstanceType,
                        options.DefaultProcessInstanceFlowType
                    ));
            });


            return new BpmNetCoreBuilder(builder.Services);
        }

        /// <summary>
        /// Registers the BpmNet core services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by BpmNet to register new services.</param>
        /// <param name="configuration">The configuration delegate used to configure the core services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetBuilder"/>.</returns>
        public static BpmNetBuilder AddCore(this BpmNetBuilder builder, Action<BpmNetCoreBuilder> configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(builder.AddCore());

            return builder;
        }
    }
}
