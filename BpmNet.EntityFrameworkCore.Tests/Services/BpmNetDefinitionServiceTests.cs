using BpmNet.EntityFrameworkCore.Tests.Orders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests
{
    [Order(1)]
    [ExcludeFromCodeCoverage]
    public class BpmNetDefinitionServiceTests
    {

        [Fact, Order(1)]
        public async Task DeployAsync_NullException()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();

            // Act and assert
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => definitionService.DeployAsync((string)null, CancellationToken.None));

            Assert.Equal("filePath", exception.ParamName);
        }

        [Fact, Order(2)]
        public async Task CreateAsync_SuccessCreate()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();

            // Act 
            var definition = await definitionService.DeployAsync(TestBuilder.PATH_SAMPLE, true, CancellationToken.None);

            // Assert
            Assert.NotNull(definition);
        }

        [Fact, Order(3)]
        public async Task DeployAsync_SuccessReplace()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();

            // Act 
            var definition = await definitionService.DeployAsync(TestBuilder.PATH_SAMPLE, true, CancellationToken.None);

            // Assert
            Assert.NotNull(definition);
        }

        [Fact, Order(4)]
        public async Task DeployAsync_NullResult()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();
            var definition = await definitionService.DeployAsync(TestBuilder.PATH_SAMPLE, true, CancellationToken.None);

            // Assert
            Assert.NotNull(definition);
        }
    }
}
