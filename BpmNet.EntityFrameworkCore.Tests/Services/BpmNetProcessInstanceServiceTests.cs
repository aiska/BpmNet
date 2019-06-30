using BpmNet.EntityFrameworkCore.Models;
using BpmNet.EntityFrameworkCore.Tests.Orders;
using BpmNet.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BpmNet.EntityFrameworkCore.Tests.Services
{
    [Order(2)]
    [ExcludeFromCodeCoverage]
    public class BpmNetProcessInstanceServiceTests
    {
        private readonly ITestOutputHelper _output;

        public BpmNetProcessInstanceServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact, Order(0)]
        public async Task StartNewProcess_Success()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act and assert
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();
            var definition = await definitionService.DeployAsync(TestBuilder.PATH_SAMPLE, true, CancellationToken.None);
            IBpmNetProcessInstanceService service = provider.GetService<IBpmNetProcessInstanceService>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            var instance = await service.StartProcessAsync("Process_1", null, CancellationToken.None);
            stopwatch.Stop();
            _output.WriteLine("Elapsed time 1st attemp processing StartNewProcessAsync : {0}ms", stopwatch.ElapsedMilliseconds);

            stopwatch = Stopwatch.StartNew();
            var instance2 = await service.StartProcessAsync("Process_1", null, CancellationToken.None);
            stopwatch.Stop();
            _output.WriteLine("Elapsed time 2nd attemp processing StartNewProcessAsync : {0}ms", stopwatch.ElapsedMilliseconds);

            Assert.NotNull(instance);
        }

        [Fact, Order(1)]
        public async Task StartNewProcess_GatewayBpmnTest()
        {
            // Arrange
            var services = TestBuilder.CreateInMemoryServices();
            var builder = TestBuilder.CreateEntityBuilder(services);

            // Act and assert
            var provider = services.BuildServiceProvider();
            var definitionService = provider.GetRequiredService<IBpmNetDefinitionService>();
            var definition = await definitionService.DeployAsync(TestBuilder.GATEWAY, true, CancellationToken.None);
            IBpmNetProcessInstanceService service = provider.GetService<IBpmNetProcessInstanceService>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            var instance = await service.StartProcessAsync("Process_Gateway", null, CancellationToken.None);
            stopwatch.Stop();
            _output.WriteLine("Elapsed time 1st attemp processing StartNewProcessAsync : {0}ms", stopwatch.ElapsedMilliseconds);

            stopwatch = Stopwatch.StartNew();
            var instance2 = await service.StartProcessAsync("Process_Gateway", null, CancellationToken.None);
            stopwatch.Stop();
            _output.WriteLine("Elapsed time 2nd attemp processing StartNewProcessAsync : {0}ms", stopwatch.ElapsedMilliseconds);

            Assert.NotNull(instance);
            Assert.Equal(27, ((BpmNetProcessInstance)instance).Flows.Count);
        }
    }
}
