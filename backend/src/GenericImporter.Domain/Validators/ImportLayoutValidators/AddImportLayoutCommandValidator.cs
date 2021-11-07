using FluentValidation;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Validators;

namespace GenericImporter.Domain.Validators.ImportLayoutValidators
{
    public class AddImportLayoutCommandValidator : CommandValidator<AddImportLayoutCommand>
    {
        public AddImportLayoutCommandValidator()
        {
            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Entity.Separator)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Separator").Message);

            RuleFor(x => x.Entity.ImportLayoutEntity)
                .IsInEnum()
                .WithMessage(DomainMessages.InvalidFormat.Format("ImportLayoutEntity").Message)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportLayoutEntity").Message);

            RuleFor(x => x.Entity.ImportLayoutColumns)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportLayoutColumns").Message);

            RuleForEach(x => x.Entity.ImportLayoutColumns).SetValidator(new ImportLayoutColumnValidator());
        }
    }
}
