using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using GenericImporter.Service.Helpers;
using Xunit;

namespace GenericImporter.Service.Tests.Helpers
{
    public class ImportAttributeHelperTests
    {
        private readonly IImportAttributeHelper _importAttributeHelper;

        public ImportAttributeHelperTests()
        {
            _importAttributeHelper = new ImportAttributeHelper();
        }

        #region FindClassPropertyByName
        [Fact(DisplayName = "FindClassPropertyByName_ShouldReturnNull_WhenNullClassType")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void FindClassPropertyByName_ShouldReturnNull_WhenNullClassType()
        {
            // Act
            var result = _importAttributeHelper.FindClassPropertyByName(null, "WillNotFind");

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "FindClassPropertyByName_ShouldReturnPropertyInfo_WhenFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void FindClassPropertyByName_ShouldReturnPropertyInfo_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = _importAttributeHelper.FindClassPropertyByName(classType, "WillFind");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(propertyInfo, result);
        }

        [Fact(DisplayName = "FindClassPropertyByName_ShouldReturnNull_WhenDontFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void FindClassPropertyByName_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);

            // Act
            var result = _importAttributeHelper.FindClassPropertyByName(classType, "WillNotFind");

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "FindClassPropertyByName_ShouldReturnNull_WhenClassHaveNoPropertyWithImportFieldAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void FindClassPropertyByName_ShouldReturnNull_WhenClassHaveNoProperties()
        {
            // Arrange
            var classType = typeof(MyClassWithoutProperties);

            // Act
            var result = _importAttributeHelper.FindClassPropertyByName(classType, "WillNotFind");

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "FindClassPropertyByName_ShouldThrowException_WhenDuplicatedImportFieldName")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void FindClassPropertyByName_ShouldThrowException_WhenDuplicatedImportFieldName()
        {
            // Arrange
            var classType = typeof(MyClassWithDuplicatedImportFieldAttribute);

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => _importAttributeHelper.FindClassPropertyByName(classType, "Duplicated"));
            Assert.Equal("Duplicated ImportFieldAttributeName in class.", ex.Message);
        }
        #endregion

        #region GetImportClassAttribute
        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnNull_WhenNullClassType")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportClassAttribute_ShouldReturnNull_WhenNullClassType()
        {
            // Act
            var result = _importAttributeHelper.GetImportClassAttribute(null);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnEmptyImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportClassAttribute_ShouldReturnEmptyImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithEmptyImportClassAttribute);

            // Act
            var result = _importAttributeHelper.GetImportClassAttribute(classType);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Class);
            Assert.Null(result.Method);
        }

        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportClassAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportClassAttribute);

            // Act
            var result = _importAttributeHelper.GetImportClassAttribute(classType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(MyClassWithImportFieldAttribute), result.Class);
            Assert.Equal("MethodAttribute", result.Method);
        }

        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnNull_WhenDontFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportClassAttribute_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithoutImportClassAttribute);

            // Act
            var result = _importAttributeHelper.GetImportClassAttribute(classType);

            // Assert
            Assert.Null(result);
        }
        #endregion

        #region GetImportFieldAttribute
        [Fact(DisplayName = "GetImportFieldAttribute_ShouldReturnNull_WhenNullPropertyInfo")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportFieldAttribute_ShouldReturnNull_WhenNullPropertyInfo()
        {
            // Act
            var result = _importAttributeHelper.GetImportFieldAttribute(null);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetImportFieldAttribute_ShouldReturnEmptyImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportFieldAttribute_ShouldReturnEmptyImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithEmptyImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = _importAttributeHelper.GetImportFieldAttribute(propertyInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Name);
        }

        [Fact(DisplayName = "GetImportFieldAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportFieldAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = _importAttributeHelper.GetImportFieldAttribute(propertyInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("WillFind", result.Name);
        }

        [Fact(DisplayName = "GetImportFieldAttribute_ShouldReturnNull_WhenPropertyHaveNoAttribute")]
        [Trait("GenericImporter - Helpers", "ImportAttributeHelper")]
        public void GetImportFieldAttribute_ShouldReturnNull_WhenPropertyHaveNoAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithoutImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = _importAttributeHelper.GetImportFieldAttribute(propertyInfo);

            // Assert
            Assert.Null(result);
        }
        #endregion
    }

    public class MyClassWithImportFieldAttribute
    {
        [ImportField(Name = "WillFind")]
        public string Name { get; set; }
    }

    public class MyClassWithEmptyImportFieldAttribute
    {
        [ImportField]
        public string Name { get; set; }
    }

    public class MyClassWithoutImportFieldAttribute
    {
        public string Name { get; set; }
    }

    public class MyClassWithoutProperties { }

    public class MyClassWithDuplicatedImportFieldAttribute
    {
        [ImportField(Name = "Duplicated")]
        public string Name { get; set; }

        [ImportField(Name = "Duplicated")]
        public string AnotherName { get; set; }
    }

    [ImportClass]
    public class MyClassWithEmptyImportClassAttribute { }

    [ImportClass(Class = typeof(MyClassWithImportFieldAttribute), Method = "MethodAttribute")]
    public class MyClassWithImportClassAttribute { }

    public class MyClassWithoutImportClassAttribute { }
}
