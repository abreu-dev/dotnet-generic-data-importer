using GenericImporter.Service.Extensions;
using GenericImporter.Service.Tests.Helpers;
using Xunit;

namespace GenericImporter.Service.Tests.Extensions
{
    public class PropertyInfoExtensionsTests
    {
        #region GetImportAttribute
        [Fact(DisplayName = "GetImportAttribute_ShouldReturnNull_WhenDontFindAttribute")]
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        public void GetImportAttribute_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithoutImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = propertyInfo.GetImportAttribute();

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetImportAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        public void GetImportAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = propertyInfo.GetImportAttribute();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("WillFind", result.Name);
        }
        #endregion

        #region SetValueByString
        [Fact(DisplayName = "SetValueByString_ShouldSetPropertyValue")]
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        public void SetValueByString_ShouldSetPropertyValue()
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithoutImportFieldAttribute).GetProperty("Name");
            var instance = new MyClassWithoutImportFieldAttribute();
            var value = "ValueSetted";

            // Act
            propertyInfo.SetValueByString(instance, value);

            // Assert
            Assert.Equal(value, instance.Name);
        }
        #endregion
    }
}
