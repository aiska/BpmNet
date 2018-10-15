using System;
using Xunit;

namespace BpmNet.Core.Tests
{
    public class BpmNetCoreHelpersTests
    {
        [Fact]
        public void FindGenericBaseType_ThrowsAnExceptionForNullType()
        {
            // Arrange
            var type = (Type)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => BpmNetCoreHelpers.FindGenericBaseType(type, type));

            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void FindGenericBaseType_ThrowsAnExceptionForNullDefinition()
        {
            // Arrange
            var type = typeof(string);
            var definition = (Type)null;

            // Act and assert
            var exception = Assert.Throws<ArgumentNullException>(() => BpmNetCoreHelpers.FindGenericBaseType(type, definition));

            Assert.Equal("definition", exception.ParamName);
        }

        [Fact]
        public void FindGenericBaseType_ThrowsAnExceptionForNonGenericType()
        {
            // Arrange
            var type = typeof(string);
            var definition = typeof(string);

            // Act and assert
            var exception = Assert.Throws<ArgumentException>(() => BpmNetCoreHelpers.FindGenericBaseType(type, definition));

            Assert.Equal("definition", exception.ParamName);
            Assert.StartsWith("The second parameter must be a generic type definition.", exception.Message);
        }

        [Fact]
        public void FindGenericBaseType_InterfaceDefinitionType()
        {
            // Arrange
            var type = typeof(ICustom3<,>);
            var definition = typeof(ICustomInterface<>);

            // Act and assert
            var generic = BpmNetCoreHelpers.FindGenericBaseType(type, definition);

            Assert.Equal(typeof(ICustomInterface<BpmNetCoreOptions>), generic);
        }

        [Fact]
        public void FindGenericBaseType_NullDefinitionType()
        {
            // Arrange
            var type = typeof(ICustom4<,>);
            var definition = typeof(ICustomInterface<>);

            // Act and assert
            var generic = BpmNetCoreHelpers.FindGenericBaseType(type, definition);

            Assert.Null(generic);
        }

        interface ICustomInterface<T> where T : BpmNetCoreOptions { }
        interface ICustom2 : ICustomInterface<BpmNetCoreOptions> { }
        interface ICustom3<T, S> : ICustom2 { }
        interface ICustom4<T, S> : ICustom5<T> where T : BpmNetCoreOptions { }
        interface ICustom5<T> where T : BpmNetCoreOptions { }

    }
}
