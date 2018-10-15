using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace BpmNet.Abstractions.Tests
{
    public class BpmNetExtensionsTests
    {
        [Fact]
        public void Constructor_ThrowsAnExceptionForNullServices()
        {
            // Arrange
            var services = (IServiceCollection)null;

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => services.AddBpmNet());

            // Assert
            Assert.Equal("services", exception.ParamName);
        }
    }
}
