using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Entities;
using System;
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
                    ImportLayoutId = Guid.Empty
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("ImportLayoutId").Message,
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
                    ImportLayoutId = Guid.NewGuid()
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
