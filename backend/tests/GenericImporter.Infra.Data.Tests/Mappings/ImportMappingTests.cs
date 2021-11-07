using GenericImporter.Domain.Entities;
using GenericImporter.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit;

namespace GenericImporter.Infra.Data.Tests.Mappings
{
    public class ImportMappingTests
    {
        [Fact(DisplayName = "Configure_ShouldHaveTableNameAsImport")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHaveTableNameAsImport()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var annotation = entityTypeBuilderImport.Metadata.FindAnnotation("Relational:TableName");
            Assert.NotNull(annotation);
            Assert.Equal("Import", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePrimaryKey")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePrimaryKey()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var primaryKey = entityTypeBuilderImport.Metadata.FindPrimaryKey();
            Assert.NotNull(primaryKey);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var property = entityTypeBuilderImport.Metadata.FindProperty("Code");
            Assert.NotNull(property);
            Assert.Equal(ValueGenerated.OnAdd, property.ValueGenerated);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyDateColumnNameAsDate")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyDateColumnNameAsDate()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var property = entityTypeBuilderImport.Metadata.FindProperty("Date");
            Assert.NotNull(property);
            var annotation = property.FindAnnotation("Relational:ColumnName");
            Assert.NotNull(annotation);
            Assert.Equal("Date", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHaveNavigationImportLayoutId")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHaveNavigationImportLayoutId()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var property = entityTypeBuilderImport.Metadata.GetNavigationMemberInfo("ImportLayout");
            Assert.NotNull(property);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyDateAsRequired")]
        [Trait("Mapping", "Import")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyDateAsRequired()
        {
            // Arrange
            var entityTypeImport = new EntityType(typeof(Import), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImport = new EntityTypeBuilder<Import>(entityTypeImport);
            var importMaping = new ImportMapping();

            // Act
            importMaping.Configure(entityTypeBuilderImport);

            // Assert
            var property = entityTypeBuilderImport.Metadata.FindProperty("Date");
            Assert.NotNull(property);
            Assert.False(property.IsNullable);
        }
    }
}
