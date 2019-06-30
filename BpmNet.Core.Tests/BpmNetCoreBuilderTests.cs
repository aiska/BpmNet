using BpmNet.Core.Services;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Serializer;
using BpmNet.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.Core.Tests
{
    [ExcludeFromCodeCoverage]
    public class BpmNetCoreBuilderTests
    {
        [Fact]
        public void Constructor_ThrowsAnExceptionForNullServices()
        {
            // Arrange
            var services = (IServiceCollection)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => new BpmNetCoreBuilder(services));

            Assert.Equal("services", exception.ParamName);
        }

        #region ReplaceDefinitionService
        [Fact]
        public void ReplaceDefinitionService_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);
            var type = (Type)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.ReplaceDefinitionService(type));

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void ReplaceDefinitionService_ThrowsAnExceptionForInvalidManager()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(() => builder.ReplaceDefinitionService(typeof(object)));

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void ReplaceDefinitionService_ThrowsAnExceptionForInvalidTypeManager()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);
            var type = typeof(OtherGenericDefinitionService<,>);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(() => builder.ReplaceDefinitionService(type));

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void ReplaceDefinitionService_OverridesDefaultOpenGenericManager()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.ReplaceDefinitionService(typeof(OpenGenericDefinitionService<>));

            // Assert
            Assert.Contains(services, service =>
                service.ServiceType == typeof(OpenGenericDefinitionService<>) &&
                service.ImplementationType == typeof(OpenGenericDefinitionService<>));
            Assert.Contains(services, service =>
                service.ServiceType == typeof(BpmNetDefinitionService<>) &&
                service.ImplementationType == typeof(OpenGenericDefinitionService<>));
            Assert.DoesNotContain(services, service =>
                service.ServiceType == typeof(BpmNetDefinitionService<>) &&
                service.ImplementationType == typeof(BpmNetDefinitionService<>));
        }

        [Fact]
        public void ReplaceDefinitionService_AddsClosedGenericManager()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.ReplaceDefinitionService<ClosedGenericDefinitionService>();
            builder.ReplaceStoreResolver<CustomStoreResolver>();
            builder.SetDefaultDefinitionEntity<CustomDefinition>();

            var provider = services.BuildServiceProvider();
            var store = provider.GetRequiredService<ClosedGenericDefinitionService>();

            // Assert
            Assert.Contains(services, service =>
                service.ServiceType == typeof(ClosedGenericDefinitionService) &&
                service.ImplementationFactory != null);
            Assert.Contains(services, service =>
                service.ServiceType == typeof(BpmNetDefinitionService<CustomDefinition>) &&
                service.ImplementationType == typeof(ClosedGenericDefinitionService));
            Assert.Contains(services, service =>
                service.ServiceType == typeof(BpmNetDefinitionService<>) &&
                service.ImplementationType == typeof(BpmNetDefinitionService<>));
        }
        #endregion

        #region ReplaceDefinitionStoreResolver
        [Fact]
        public void ReplaceStoreResolver_ThrowsAnExceptionForInvalidStoreResolver()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(() => builder.ReplaceStoreResolver(typeof(object)));

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void ReplaceStoreResolver_ThrowsAnExceptionForNullResolver()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);
            var type = (Type)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.ReplaceStoreResolver(type));

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void ReplaceStoreResolver_OverridesDefaultResolver()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            var type = Mock.Of<IBpmNetStoreResolver>().GetType();

            // Act
            builder.ReplaceStoreResolver(type);

            var provider = services.BuildServiceProvider();
            var store = provider.GetRequiredService<IBpmNetStoreResolver>();

            // Assert
            Assert.IsType(type, store);
        }

        [Fact]
        public void ReplaceStoreResolver_OverridesDefaultTypeResolver()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            var type = typeof(CustomStoreResolver);

            // Act
            builder.ReplaceStoreResolver<CustomStoreResolver>();

            var provider = services.BuildServiceProvider();
            var store = provider.GetRequiredService<IBpmNetStoreResolver>();

            // Assert
            Assert.IsType(type, store);
        }
        #endregion

        #region SetDefaultDefinitionEntity
        [Fact]
        public void SetDefaultDefinitionEntity_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                return builder.SetDefaultDefinitionEntity(type: null);
            });

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void SetDefaultDefinitionEntity_ThrowsAnExceptionForInvalidType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {
                return builder.SetDefaultDefinitionEntity(type: typeof(int));
            });

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void SetDefaultDefinitionEntity_EntityIsCorrectlySet()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.SetDefaultDefinitionEntity<CustomDefinition>();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomDefinition), options.DefaultDefinitionType);
        }
        #endregion

        #region SetDefaultProcessInstanceEntity
        [Fact]
        public void SetDefaultProcessInstanceEntity_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                return builder.SetDefaultProcessInstanceTypeEntity(type: null);
            });

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void SetDefaultProcessInstanceEntity_ThrowsAnExceptionForInvalidType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {
                return builder.SetDefaultProcessInstanceTypeEntity(type: typeof(int));
            });

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void SetDefaultProcessInstanceEntity_EntityIsCorrectlySet()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.SetDefaultProcessInstanceTypeEntity<CustomProcessInstance>();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomProcessInstance), options.DefaultProcessInstanceType);
        }
        #endregion

        #region SetDefaultProcessInstanceFlowEntity
        [Fact]
        public void SetDefaultProcessInstanceFlowEntity_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                return builder.SetDefaultProcessInstanceFlowTypeEntity(type: null);
            });

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void SetDefaultProcessInstanceFlowEntity_ThrowsAnExceptionForInvalidType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {
                return builder.SetDefaultProcessInstanceFlowTypeEntity(type: typeof(int));
            });

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void SetDefaultProcessInstanceFlowEntity_EntityIsCorrectlySet()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.SetDefaultProcessInstanceFlowTypeEntity<CustomInstanceFlow>();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomInstanceFlow), options.DefaultProcessInstanceFlowType);
        }
        #endregion

        #region SetDefaultHistoryFlowEntity
        [Fact]
        public void SetDefaultHistoryFlowEntity_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                return builder.SetDefaultHistoryFlowTypeEntity(type: null);
            });

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void SetDefaultHistoryFlowEntity_ThrowsAnExceptionForInvalidType()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {
                return builder.SetDefaultHistoryFlowTypeEntity(type: typeof(int));
            });

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void SetDefaultHistoryFlowEntity_EntityIsCorrectlySet()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);

            // Act
            builder.SetDefaultHistoryFlowTypeEntity<CustomInstanceFlow>();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomInstanceFlow), options.DefaultHistoryFlowType);
        }
        #endregion

        [Fact]
        public void Configure_ThrowsAnExceptionForNullConfiguration()
        {
            // Arrange
            var services = CreateServices();
            var builder = CreateBuilder(services);


            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.Configure(null));

            Assert.Equal("configuration", exception.ParamName);
        }

        private static BpmNetCoreBuilder CreateBuilder(IServiceCollection services) => services.AddBpmNet().AddCore();

        private static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();

            return services;
        }

        #region Definition Service
        private class OpenGenericDefinitionService<TDefinition> : BpmNetDefinitionService<TDefinition>
            where TDefinition : class, IBpmNetDefinition, new()
        {
            public OpenGenericDefinitionService(IBpmNetStoreResolver storeResolver, IBpmNetSerializer serializer, ILogger<BpmNetDefinitionService<TDefinition>> logger) : base(storeResolver, serializer, logger)
            {
            }
        }

        private class ClosedGenericDefinitionService : BpmNetDefinitionService<CustomDefinition>
        {
            public ClosedGenericDefinitionService(IBpmNetStoreResolver storeResolver, IBpmNetSerializer serializer, ILogger<BpmNetDefinitionService<CustomDefinition>> logger) : base(storeResolver, serializer, logger)
            {
            }
        }


        private class OtherGenericDefinitionService<TDefinition, THistory> : BpmNetDefinitionService<TDefinition>
            where TDefinition : class, IBpmNetDefinition, new()
            where THistory : class, IBpmNetHistory
        {
            public OtherGenericDefinitionService(IBpmNetStoreResolver storeResolver, IBpmNetSerializer serializer, ILogger<BpmNetDefinitionService<TDefinition>> logger) : base(storeResolver, serializer, logger)
            {
            }
        }
        #endregion

        private class CustomStoreResolver : IBpmNetStoreResolver
        {
            IBpmNetDefinitionStore<TDefinition> IBpmNetStoreResolver.GetDefinitionStore<TDefinition>()
            {
                return null;
            }

            IBpmNetHistoryStore<THistory> IBpmNetStoreResolver.GetHistoryStore<THistory>()
            {
                return null;
            }

            IBpmNetProcessInstanceStore<TInstance, TInstanceFlow> IBpmNetStoreResolver.GetProcessInstanceStore<TInstance, TInstanceFlow>()
            {
                return null;
            }
        }


        public class CustomDefinition : IBpmNetDefinition
        {
            public string Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Xml { get; set; }
        }
        public class CustomProcessInstance : IProcessInstance
        {
            public Guid Id { get; set; }
            public string ProcessId { get; set; }
            public string BussinesKey { get; set; }
            public string TenantId { get; set; }
            public InstanceStatus Status { get; set; }
        }

        public class CustomInstanceFlow : IBpmNetInstanceFlow
        {
            public Guid Id { get; set; }
            public FlowElementType ElementType { get; set; }
            public string FlowId { get; set; }
            public Guid ProcessInstanceId { get; set; }
            public DateTime Start { get; set; }
            public DateTime? Finnish { get; set; }
            public int Duration { get; set; }
            public FlowResult Status { get; set; }
        }
    }
}
