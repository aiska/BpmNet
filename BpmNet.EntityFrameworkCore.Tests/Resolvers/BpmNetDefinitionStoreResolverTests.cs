using BpmNet.Core.Model;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.EntityFrameworkCore.Resolvers;
using BpmNet.EntityFrameworkCore.Stores;
using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Text;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests.Resolvers
{
    public class BpmNetDefinitionStoreResolverTests
    {
        #region Definition
        [Fact]
        public void GetDefinitionStore_ReturnsCustomStoreCorrespondingToTheSpecifiedTypeWhenAvailable()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSingleton(Mock.Of<IBpmNetDefinitionStore<BpmNetDefinition>>());

            var options = Mock.Of<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>();
            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(options, provider);

            // Act and assert
            Assert.NotNull(resolver.GetDefinitionStore<BpmNetDefinition>());
        }

        [Fact]
        public void GetDefinitionStore_ThrowsAnExceptionForInvalidEntityType()
        {
            // Arrange
            var services = new ServiceCollection();

            var options = Mock.Of<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>();
            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(options, provider);

            // Act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => resolver.GetDefinitionStore<CustomDefinition>());

            Assert.Equal(new StringBuilder()
                .AppendLine("The specified definition type is not compatible with the Entity Framework Core stores. ")
                .Append("When enabling the Entity Framework Core stores, make sure your custom entity is inherit From ")
                .Append("'BpmNetDefinition' in your entity model (from the 'BpmNet.Core' package) ")
                .ToString(), exception.Message);
        }

        [Fact]
        public void GetDefinitionStore_ThrowsAnExceptionForNullDbContext()
        {
            // Arrange
            var services = new ServiceCollection();

            var options = Mock.Of<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>(
                mock => mock.CurrentValue == new BpmNetEntityFrameworkCoreOptions
                {
                    DbContextType = null
                });

            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(options, provider);

            // Act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => resolver.GetDefinitionStore<BpmNetDefinition>());

            //Assert.Equal(new StringBuilder()
            //    .AppendLine("No Entity Framework Core context was specified in the BpmNet options.")
            //    .Append("To configure the BpmNet Entity Framework Core stores to use a specific 'DbContext', ")
            //    .Append("use 'options.UseEntityFrameworkCore().UseDbContext<TContext>()'.")
            //    .ToString(), exception.Message);
        }

        [Fact]
        public void GetDefinitionStore_ReturnsDefaultStoreCorrespondingToTheSpecifiedTypeWhenAvailable()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSingleton(Mock.Of<IBpmNetDefinitionStore<BpmNetDefinition>>());
            services.AddSingleton(CreateStore<BpmNetDefinition>());

            var options = Mock.Of<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>(
                mock => mock.CurrentValue == new BpmNetEntityFrameworkCoreOptions
                {
                    DbContextType = typeof(DbContext)
                });

            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(options, provider);

            // Act and assert
            Assert.NotNull(resolver.GetDefinitionStore<BpmNetDefinition>());
        }
        #endregion

        private static IBpmNetDefinitionStore<TDefinition> CreateStore<TDefinition>()
            where TDefinition : class, IBpmNetDefinition, new()
            => new Mock<BpmNetDefinitionStore<DbContext, TDefinition>>(
            Mock.Of<DbContext>(),
            Mock.Of<IMemoryCache>(),
            Mock.Of<IOptionsMonitor<BpmNetEntityFrameworkCoreOptions>>()).Object;

        public class CustomDefinition : IBpmNetDefinition
        {
            public string Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Xml { get; set; }
        }
        public class CustomItemDefinition { }
        public class CustomProcess { }

    }
}
