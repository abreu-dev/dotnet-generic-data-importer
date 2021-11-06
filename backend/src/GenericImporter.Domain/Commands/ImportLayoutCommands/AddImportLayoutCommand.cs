using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Validators.ImportLayoutValidators;
using System;

namespace GenericImporter.Domain.Commands.ImportLayoutCommands
{
    public class AddImportLayoutCommand : Command
    {
        public ImportLayout Entity { get; set; }

        public AddImportLayoutCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddImportLayoutCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
