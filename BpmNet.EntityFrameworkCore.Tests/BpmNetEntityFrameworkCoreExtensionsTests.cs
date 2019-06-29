using BpmNet.Core;
using BpmNet.EntityFrameworkCore.Configurations;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.EntityFrameworkCore.Resolvers;
using BpmNet.EntityFrameworkCore.Stores;
using BpmNet.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests
{
    public class BpmNetEntityFrameworkCoreExtensionsTests
    {
        [Fact]
        public void UseEntityFrameworkCore_ThrowsAnExceptionForNullBuilder()
        {
            // Arrange
            var builder = (BpmNetCoreBuilder)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.UseEntityFrameworkCore());

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void UseEntityFrameworkCore_ThrowsAnExceptionForNullBuilderWithConfiguration()
        {
            // Arrange
            var builder = (BpmNetCoreBuilder)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.UseEntityFrameworkCore(configuration: null));

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void UseEntityFrameworkCore_ThrowsAnExceptionForNullConfiguration()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetCoreBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.UseEntityFrameworkCore(configuration: null));

            Assert.Equal("configuration", exception.ParamName);
        }

        [Fact]
        public void UseEntityFrameworkCore_RegistersCachingServices()
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetCoreBuilder(services);

            // Act
            builder.UseEntityFrameworkCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == typeof(IMemoryCache));
        }

        [Fact]
        public void UseEntityFrameworkCore_RegistersDefaultEntities()
        {
            // Arrange
            var services = new ServiceCollection().AddOptions();
            var builder = new BpmNetCoreBuilder(services);

            // Act
            builder.UseEntityFrameworkCore(opt => { });

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(BpmNetDefinition), options.DefaultDefinitionType);
            Assert.Equal(typeof(BpmNetProcessInstance), options.DefaultProcessInstanceType);
            Assert.Equal(typeof(BpmNetInstanceFlow), options.DefaultProcessInstanceFlowType);
            Assert.Equal(typeof(BpmNetHistory), options.DefaultHistoryFlowType);
        }

        [Theory]
        [InlineData(typeof(IBpmNetStoreResolver), typeof(BpmNetStoreResolver))]
        public void UseEntityFrameworkCore_RegistersEntityFrameworkCoreStoreResolvers(Type serviceType, Type implementationType)
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = TestBuilder.CreateBuilder(services);

            // Act & Assert
            Assert.Contains(services, service => service.ServiceType == serviceType && service.ImplementationType == implementationType);
        }

        [Theory]
        [InlineData(typeof(BpmNetDefinitionStore<,>))]
        [InlineData(typeof(BpmNetHistoryStore<,>))]
        [InlineData(typeof(BpmNetProcessInstanceStore<,,>))]

        public void UseEntityFrameworkCore_RegistersEntityFrameworkCoreStore(Type type)
        {
            // Arrange
            var services = new ServiceCollection();
            var builder = new BpmNetCoreBuilder(services);

            // Act
            builder.UseEntityFrameworkCore();

            // Assert
            Assert.Contains(services, service => service.ServiceType == type && service.ImplementationType == type);
        }

        [Fact]
        public void UseBpmNet_ThrowsAnExceptionForNullDbContextOptionsBuilder()
        {
            // Arrange
            var builder = (DbContextOptionsBuilder)null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => builder.UseBpmNet());

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void UseBpmNet_RegistersDefaultEntityDbContextOptionsBuilder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CustomContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .UseBpmNet().Options;

            // Act
            using (var context = new CustomContext(options))
            {
                var dbSet = context.Set<BpmNetDefinition>();
                Assert.NotNull(dbSet);
            }
        }

        [Fact]
        public void UseBpmNet_ThrowsAnExceptionForNullModelBuilder()
        {
            // Arrange
            var builder = (ModelBuilder)null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => builder.UseBpmNet());

            Assert.Equal("builder", exception.ParamName);
        }

        [Fact]
        public void UseBpmNet_RegistersDefaultEntityConfigurations()
        {
            // Arrange
            var builder = new Mock<ModelBuilder>(new ConventionSet());

            // Act
            builder.Object.UseBpmNet();

            // Assert
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetDefinitionConfiguration>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetProcessInstanceConfiguration<BpmNetProcessInstance, BpmNetInstanceFlow>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetInstanceFlowConfiguration<BpmNetInstanceFlow>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetHistoryConfiguration<BpmNetHistory>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetProcessConfiguration>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetRootConfiguration>()), Times.Once());
        }


        [Fact]
        public void UseBpmNet_RegistersCustomEntityConfigurations()
        {
            // Arrange
            var builder = new Mock<ModelBuilder>(new ConventionSet());

            // Act
            builder.Object.UseBpmNet<CustomProcessInstance, CustomInstanceFlow, CustomHistory>();

            // Assert
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetDefinitionConfiguration>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetProcessInstanceConfiguration<CustomProcessInstance, CustomInstanceFlow>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetInstanceFlowConfiguration<CustomInstanceFlow>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetHistoryConfiguration<CustomHistory>>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetProcessConfiguration>()), Times.Once());
            builder.Verify(mock => mock.ApplyConfiguration(
                It.IsAny<BpmNetRootConfiguration>()), Times.Once());
        }

    }
}
