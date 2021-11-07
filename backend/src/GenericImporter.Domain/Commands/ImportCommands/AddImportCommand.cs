using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Validators.ImportValidators;
using System;

namespace GenericImporter.Domain.Commands.ImportCommands
{
    public class AddImportCommand : Command
    {
        public Import Entity { get; set; }

        public AddImportCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddImportCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
