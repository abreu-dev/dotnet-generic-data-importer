using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Validators.XptoValidators;
using System;

namespace GenericImporter.Domain.Commands.XptoCommands
{
    public class AddXptoCommand : Command
    {
        public Xpto Entity { get; set; }

        public AddXptoCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddXptoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
