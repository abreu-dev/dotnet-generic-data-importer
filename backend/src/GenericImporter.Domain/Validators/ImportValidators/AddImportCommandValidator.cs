using FluentValidation;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Validators;

namespace GenericImporter.Domain.Validators.ImportValidators
{
    public class AddImportCommandValidator : CommandValidator<AddImportCommand>
    {
        public AddImportCommandValidator()
        {
            RuleFor(x => x.Entity.ImportLayoutId)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportLayoutId").Message);

            RuleFor(x => x.Entity.ImportItems)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportItems").Message);
        }
    }
}
