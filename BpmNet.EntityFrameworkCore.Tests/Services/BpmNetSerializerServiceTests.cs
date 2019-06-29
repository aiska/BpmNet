using BpmNet.Core.Services;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class BpmNetSerializerServiceTests
    {
        private static readonly string PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"BpmnFile\sample.bpmn");

        [Fact]
        public void DeserializeDefinitions_DeserializeObject()
        {
            // Arrange
            var serializer = new BpmNetSerializerService();

            // Act
            var result = serializer.Deserialize(PATH);

            // Assert
            Assert.NotNull(result);
        }
    }
}
