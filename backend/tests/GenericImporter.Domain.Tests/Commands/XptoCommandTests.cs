using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Entities;
using System.Linq;
using Xunit;

namespace GenericImporter.Domain.Tests.Commands
{
    public class XptoCommandTests
    {
        [Fact(DisplayName = "AddXptoCommand_ShouldFailValidation_WhenEmptyName")]
        [Trait("Command", "Xpto")]
        public void AddXptoCommand_ShouldFailValidation_WhenEmptyName()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = ""
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Name").Message, 
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddXptoCommand_ShouldBeValid_WhenBeWithinValidationRules")]
        [Trait("Command", "Xpto")]
        public void AddXptoCommand_ShouldBeValid_WhenBeWithinValidationRules()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto"
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
