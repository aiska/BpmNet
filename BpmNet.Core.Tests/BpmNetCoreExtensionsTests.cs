using BpmNet.Core.Resolvers;
using BpmNet.Core.Services;
using BpmNet.Resolvers;
using BpmNet.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace BpmNet.Core.Tests
{
    [ExcludeFromCodeCoverage]
    public class BpmNetCoreExtensionsTests
    {
        [Fact]
        public void AddCore_ThrowsAnExceptionForNullBuilder()
        {
            // Arrange
            var builder = (BpmNetBuilder)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.AddCore());

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void AddCore_ThrowsAnExceptionForNullServiceBuilder()
        {
            // Arrange
            var builder = (BpmNetBuilder)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.AddCore(configuration: null));

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void AddCore_ThrowsAnExceptionForNullConfiguration()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.AddCore(configuration: null));

            Assert.Equal("configuration", exception.ParamName);
        }

        [Fact]
        public void AddCore_WithConfiguration()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);
            var configuration = Mock.Of<Action<BpmNetCoreBuilder>>();
            // Act and assert
            builder.AddCore(configuration);

            // Assert
            Assert.Contains(services, service => service.ServiceType == typeof(IBpmNetProcessInstanceService));
        }

        [Fact]
        public void AddCore_InvalidProcessFlowService()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);
            var configuration = Mock.Of<Action<BpmNetCoreBuilder>>();

            // Act
            builder.AddCore();
            var provider = services.BuildServiceProvider();

            var exception = Assert.Throws<InvalidOperationException>(() => provider.GetService(typeof(IBpmNetProcessInstanceService)));

            // Assert
            Assert.Equal(new StringBuilder()
                .Append("No default entity type was configured in the BpmNet core options, ")
                .AppendLine("which generally indicates that one or more store was not registered in the DI container.")
                .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                .Append("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                .ToString(), exception.Message);
        }

        [Fact]
        public void AddCore_InvalidProcessInstanceService()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);
            var configuration = Mock.Of<Action<BpmNetCoreBuilder>>();

            // Act
            builder.AddCore();
            var provider = services.BuildServiceProvider();

            var exception = Assert.Throws<InvalidOperationException>(() => provider.GetService(typeof(IBpmNetProcessInstanceService)));

            // Assert
            Assert.Equal(new StringBuilder()
                .Append("No default entity type was configured in the BpmNet core options, ")
                .AppendLine("which generally indicates that one or more store was not registered in the DI container.")
                .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                .Append("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                .ToString(), exception.Message);
        }

        [Fact]
        public void AddCore_RegistersLoggingServices()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == typeof(ILogger<>));
        }

        [Fact]
        public void AddCore_RegistersOptionsServices()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == typeof(IOptions<>));
        }

        [Theory]

        [InlineData(typeof(BpmNetDefinitionService<,>))]
        [InlineData(typeof(ProcessFlowService<,,,>))]
        public void AddCore_RegistersDefaultManagers(Type type)
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == type && service.ImplementationType == type);
        }

        [Theory]
        [InlineData(typeof(IBpmNetStoreResolver), typeof(BpmNetStoreResolver))]
        public void AddCore_RegistersDefaultResolvers(Type serviceType, Type implementationType)
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == serviceType &&
                                                 service.ImplementationType == implementationType);
        }

        [Theory]
        [InlineData(typeof(IBpmNetProcessInstanceService))]
        
        public void AddCore_RegistersUntypedProxies(Type type)
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == type && service.ImplementationFactory != null);
        }

        [Fact]
        public void AddCore_ResolvingUntypedDefinitionServiceThrowsAnExceptionWhenDefaultEntityIsNotSet()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetBuilder(services);

            // Act
            builder.AddCore();

            // Assert
            var provider = services.BuildServiceProvider();

            var exception = Assert.Throws<InvalidOperationException>(delegate
            {
                return provider.GetRequiredService<IBpmNetDefinitionService>();
            });

            Assert.Equal(new StringBuilder()
                .Append("No default entity type was configured in the BpmNet core options, ")
                .AppendLine("which generally indicates that one or more store was not registered in the DI container.")
                .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                .Append("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                .ToString(), exception.Message);
        }

        public class BpmNetDefinition { }
    }
}
