using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericImporter.Domain.Tests.Commands
{
    public class ImportCommandTests
    {
        [Fact(DisplayName = "AddImportCommand_ShouldFailValidation_WhenEmptyImportLayoutId")]
        [Trait("Command", "Import")]
        public void AddImportCommand_ShouldFailValidation_WhenEmptyImportLayoutId()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.Empty,
                    ImportItems = new List<ImportItem>()
                    {
                        new ImportItem()
                        {
                            ImportFileLine = "ImportFileLine"
                        }
                    }
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("ImportLayoutId").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportCommand_ShouldFailValidation_WhenEmptyImportItems")]
        [Trait("Command", "Import")]
        public void AddImportCommand_ShouldFailValidation_WhenEmptyImportItems()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.NewGuid(),
                    ImportItems = new List<ImportItem>()
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("ImportItems").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddImportCommand_ShouldBeValid_WhenBeWithinValidationRules")]
        [Trait("Command", "Import")]
        public void AddImportCommand_ShouldBeValid_WhenBeWithinValidationRules()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.NewGuid(),
                    ImportItems = new List<ImportItem>()
                    {
                        new ImportItem()
                        {
                            ImportFileLine = "ImportFileLine"
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
