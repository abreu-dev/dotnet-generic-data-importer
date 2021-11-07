using GenericImporter.Domain.Core.Common;
using System.ComponentModel;
using Xunit;

namespace GenericImporter.Domain.Core.Tests.Common
{
    public class EnumExtensionMethodsTests
    {
        [Fact(DisplayName = "GetDescription_ShouldReturnNull_WhenDescriptionNotInformed")]
        [Trait("Core - Common", "EnumExtensionMethods")]
        public void GetDescription_ShouldReturnNull_WhenDescriptionNotInformed()
        {
            // Arrange
            var myEnumConcrete = MyEnumConcrete.NotInformed;

            // Act
            var result = EnumExtensionMethods.GetDescription(myEnumConcrete);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetDescription_ShouldReturnDescription_WhenDescriptionInformed")]
        [Trait("Core - Common", "EnumExtensionMethods")]
        public void GetDescription_ShouldReturnDescription_WhenDescriptionInformed()
        {
            // Arrange
            var myEnumConcrete = MyEnumConcrete.Informed;

            // Act
            var result = EnumExtensionMethods.GetDescription(myEnumConcrete);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Informed Description", result);
        }
    }

    public enum MyEnumConcrete
    {
        NotInformed,
        [Description("Informed Description")]
        Informed
    }
}
