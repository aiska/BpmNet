using BpmNet.Core.Services;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class BpmNetSerializerServiceTests
    {
        private static readonly string PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"BpmnFile\sample.bpmn");

        [Fact]
        public async Task DeserializeDefinitions_DeserializeObjectAsync()
        {
            // Arrange
            var serializer = new BpmNetSerializerService();

            // Act
            var result = await serializer.DeserializeBpmnFileAsync(PATH, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
