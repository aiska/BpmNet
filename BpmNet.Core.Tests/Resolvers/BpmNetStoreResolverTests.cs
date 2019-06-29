using BpmNet.Core.Resolvers;
using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Text;
using Xunit;

namespace BpmNet.Core.Tests.Resolvers
{
    public class BpmNetStoreResolverTests
    {
        #region Definitions
        [Fact]
        public void GetDefinitionStore_ThrowsAnExceptionWhenStoreCannotBeFound()
        {
            // Arrange
            var services = new ServiceCollection();
            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(provider);

            // Act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => resolver.GetDefinitionStore<CustomDefinition>());

            Assert.Equal(new StringBuilder()
                .AppendLine("No definition store has been registered in the dependency injection container.")
                .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                .Append("To register a custom store, create an implementation of 'IBpmNetDefinitionStore' and ")
                .Append("use 'services.AddBpmNet().AddCore().ReplaceDefinitionStore()' to add it to the DI container.")
                .ToString(), exception.Message);
        }

        [Fact]
        public void GetDefinitionStore_ReturnsCustomStoreCorrespondingToTheSpecifiedType()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSingleton(Mock.Of<IBpmNetDefinitionStore<CustomDefinition>>());

            var provider = services.BuildServiceProvider();
            var resolver = new BpmNetStoreResolver(provider);

            // Act and assert
            Assert.NotNull(resolver.GetDefinitionStore<CustomDefinition>());
        }
        #endregion

        public class CustomDefinition : IBpmNetDefinition
        {
            public string Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Xml { get; set; }
        }
    }
}
