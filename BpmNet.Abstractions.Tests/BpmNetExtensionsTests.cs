using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.Abstractions.Tests
{
    [ExcludeFromCodeCoverage]
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
