using FluentValidation;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Validators;

namespace GenericImporter.Domain.Validators.XptoValidators
{
    public class AddXptoCommandValidator : CommandValidator<AddXptoCommand>
    {
        public AddXptoCommandValidator()
        {
            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Entity.Date)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Date").Message);

            RuleFor(x => x.Entity.Version)
                .GreaterThanOrEqualTo(1)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Version", 1).Message);

            RuleFor(x => x.Entity.Value)
                .GreaterThanOrEqualTo(1)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Value", 1).Message);
        }
    }
}
