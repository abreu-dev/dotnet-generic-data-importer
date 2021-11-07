using GenericImporter.Domain.Entities;
using GenericImporter.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit;

namespace GenericImporter.Infra.Data.Tests.Mappings
{
    public class ImportLayoutMappingTests
    {
        [Fact(DisplayName = "Configure_ShouldHaveTableNameAsImportLayout")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHaveTableNameAsImportLayout()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var annotation = entityTypeBuilderImportLayout.Metadata.FindAnnotation("Relational:TableName");
            Assert.NotNull(annotation);
            Assert.Equal("ImportLayout", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePrimaryKey")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePrimaryKey()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var primaryKey = entityTypeBuilderImportLayout.Metadata.FindPrimaryKey();
            Assert.NotNull(primaryKey);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("Code");
            Assert.NotNull(property);
            Assert.Equal(ValueGenerated.OnAdd, property.ValueGenerated);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyNameColumnNameAsName")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyNameColumnNameAsName()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("Name");
            Assert.NotNull(property);
            var annotation = property.FindAnnotation("Relational:ColumnName");
            Assert.NotNull(annotation);
            Assert.Equal("Name", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyNameAsRequired")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyNameAsRequired()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("Name");
            Assert.NotNull(property);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertySeparatorColumnNameAsSeparator")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertySeparatorColumnNameAsSeparator()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("Separator");
            Assert.NotNull(property);
            var annotation = property.FindAnnotation("Relational:ColumnName");
            Assert.NotNull(annotation);
            Assert.Equal("Separator", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertySeparatorAsRequired")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertySeparatorAsRequired()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("Separator");
            Assert.NotNull(property);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyImportLayoutEntityColumnNameAsImportLayoutEntity")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyImportLayoutEntityColumnNameAsImportLayoutEntity()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("ImportLayoutEntity");
            Assert.NotNull(property);
            var annotation = property.FindAnnotation("Relational:ColumnName");
            Assert.NotNull(annotation);
            Assert.Equal("ImportLayoutEntity", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyImportLayoutEntityAsRequired")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyImportLayoutEntityAsRequired()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.FindProperty("ImportLayoutEntity");
            Assert.NotNull(property);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHaveNavigationImportLayoutColumns")]
        [Trait("Mapping", "ImportLayout")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHaveNavigationImportLayoutColumns()
        {
            // Arrange
            var entityTypeImportLayout = new EntityType(typeof(ImportLayout), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderImportLayout = new EntityTypeBuilder<ImportLayout>(entityTypeImportLayout);
            var importLayoutMaping = new ImportLayoutMapping();

            // Act
            importLayoutMaping.Configure(entityTypeBuilderImportLayout);

            // Assert
            var property = entityTypeBuilderImportLayout.Metadata.GetNavigationMemberInfo("ImportLayoutColumns");
            Assert.NotNull(property);
        }
    }
}
