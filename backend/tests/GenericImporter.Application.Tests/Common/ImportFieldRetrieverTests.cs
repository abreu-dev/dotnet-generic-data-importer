using GenericImporter.Application.Common;
using GenericImporter.Domain.Common;
using GenericImporter.Domain.Enums;
using Xunit;

namespace GenericImporter.Application.Tests.Common
{
    public class ImportFieldRetrieverTests
    {
        private readonly IImportFieldRetriever _importFieldRetriever;

        public ImportFieldRetrieverTests()
        {
            _importFieldRetriever = new ImportFieldRetriever();
        }

        [Fact(DisplayName = "GetProperties_ShouldReturnEmptyPropertyInfoArray_WhenTypeNotFound")]
        [Trait("Common", "ImportFieldRetriever")]
        public void GetProperties_ShouldReturnEmptyPropertyInfoArray_WhenTypeNotFound()
        {
            // Arrange
            var importLayoutEntity = ImportLayoutEntity.Uninformed;

            // Act
            var result = _importFieldRetriever.GetProperties(importLayoutEntity);

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "GetProperties_ShouldReturnPropertyInfoArray_WhenTypeFound")]
        [Trait("Common", "ImportFieldRetriever")]
        public void GetProperties_ShouldReturnPropertyInfoArray_WhenTypeFound()
        {
            // Arrange
            var importLayoutEntity = ImportLayoutEntity.Xpto;

            // Act
            var result = _importFieldRetriever.GetProperties(importLayoutEntity);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
