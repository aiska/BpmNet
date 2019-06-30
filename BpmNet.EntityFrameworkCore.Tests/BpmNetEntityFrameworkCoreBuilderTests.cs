using BpmNet.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests
{
    [ExcludeFromCodeCoverage]
    public class BpmNetEntityFrameworkCoreBuilderTests
    {
        [Fact]
        public void Constructor_ThrowsAnExceptionForNullServices()
        {
            // Arrange
            var services = (IServiceCollection)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => new BpmNetEntityFrameworkCoreBuilder(services));

            Assert.Equal("services", exception.ParamName);
        }

        [Fact]
        public void Constructor_ThrowsAnExceptionForNullConfiguration()
        {
            // Arrange
            var services = TestBuilder.CreateServices();
            var builder = TestBuilder.CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => builder.Configure(null));

            Assert.Equal("configuration", exception.ParamName);
        }

        [Fact]
        public void ReplaceDefaultEntities_EntitiesAreCorrectlyReplaced()
        {
            // Arrange
            var services = TestBuilder.CreateServices();
            var builder = TestBuilder.CreateBuilder(services);

            // Act
            builder.ReplaceDefaultEntities<CustomDefinition, CustomProcess, CustomProcessInstance, CustomInstanceFlow, CustomHistory>();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomDefinition), options.DefaultDefinitionType);
            Assert.Equal(typeof(CustomDefinition), options.DefaultDefinitionType);
            Assert.Equal(typeof(CustomProcessInstance), options.DefaultProcessInstanceType);
            Assert.Equal(typeof(CustomInstanceFlow), options.DefaultProcessInstanceFlowType);
            Assert.Equal(typeof(CustomHistory), options.DefaultHistoryFlowType);
        }


        [Fact]
        public void UseDbContext_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var services = TestBuilder.CreateServices();
            var builder = TestBuilder.CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(delegate
            {
                return builder.UseDbContext(type: null);
            });

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void UseDbContext_ThrowsAnExceptionForInvalidType()
        {
            // Arrange
            var services = TestBuilder.CreateServices();
            var builder = TestBuilder.CreateBuilder(services);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {
                return builder.UseDbContext(typeof(object));
            });

            Assert.Equal("type", exception.ParamName);
            Assert.StartsWith("The specified type is invalid.", exception.Message);
        }

        [Fact]
        public void UseDbContext_SetsDbContextTypeInOptions()
        {
            // Arrange
            var services = TestBuilder.CreateServices();
            var builder = TestBuilder.CreateBuilder(services);

            // Act
            builder.UseDbContext<CustomDbContext>();
            builder.UseCaching();

            // Assert
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>().CurrentValue;

            Assert.Equal(typeof(CustomDbContext), options.DbContextType);
            Assert.True(options.EnableCaching);
        }
    }
}
