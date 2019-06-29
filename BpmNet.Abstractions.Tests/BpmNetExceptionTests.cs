using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace BpmNet.Abstractions.Tests
{
    [ExcludeFromCodeCoverage]
    public class BpmNetExceptionTests
    {
        [Fact]
        public void Constructor_ThrowBpmNetException()
        {
            // Arrange & Act
            var exception = new BpmNetException(BpmNetConstants.Exceptions.ConcurrencyError, new StringBuilder()
                .AppendLine("This is sample exception.")
                .ToString(), new Exception());

            // Assert
            Assert.Equal(BpmNetConstants.Exceptions.ConcurrencyError, exception.Reason);
        }

    }
}
