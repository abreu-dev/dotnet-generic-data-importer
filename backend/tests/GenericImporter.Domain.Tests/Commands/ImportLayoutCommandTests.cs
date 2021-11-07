using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericImporter.Domain.Tests.Commands
{
    public class ImportLayoutCommandTests
    {
        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenEmptyName")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenEmptyName()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Name").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenEmptySeparator")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenEmptySeparator()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = "",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Separator").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutEntityUninformed")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutEntityUninformed()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Uninformed,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("ImportLayoutEntity").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutEntityInvalid")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutEntityInvalid()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = (ImportLayoutEntity)10,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.InvalidFormat.Format("ImportLayoutEntity").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenEmptyImportLayoutColumns")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenEmptyImportLayoutColumns()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("ImportLayoutColumns").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenEmptyImportLayoutColumName")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenEmptyImportLayoutColumName()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Name").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutColumPositionLessThanOne")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldFailValidation_WhenImportLayoutColumPositionLessThanOne()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 0
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.MustBeGreatherOrEqual.Format("Position", 1).Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportLayoutCommand_ShouldBeValid_WhenBeWithinValidationRules")]
        [Trait("Command", "ImportLayout")]
        public void AddImportLayoutCommand_ShouldBeValid_WhenBeWithinValidationRules()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.True(command.ValidationResult.IsValid);
            Assert.Empty(command.ValidationResult.Errors);
        }
    }
}
