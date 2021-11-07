using FluentValidation;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Domain.Validators.ImportLayoutValidators
{
    public class ImportLayoutColumnValidator : AbstractValidator<ImportLayoutColumn>
    {
        public ImportLayoutColumnValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Position)
                .GreaterThanOrEqualTo(1)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Position", 1).Message);
        }
    }
}
