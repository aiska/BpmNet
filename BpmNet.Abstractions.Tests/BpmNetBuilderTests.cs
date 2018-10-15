using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace BpmNet.Abstractions.Tests
{
    public class BpmNetBuilderTests
    {
        [Fact]
        public void Constructor_ThrowsAnExceptionForNullServices()
        {
            // Arrange
            var services = (IServiceCollection)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => new BpmNetBuilder(services));

            Assert.Equal("services", exception.ParamName);
        }
    }
}
