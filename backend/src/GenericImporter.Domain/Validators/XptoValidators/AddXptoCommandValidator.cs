using FluentValidation;
using GenericImporter.Domain.Commands.XptoCommands;
using Core.Domain.Common;
using Core.Domain.Validators;

namespace GenericImporter.Domain.Validators.XptoValidators
{
    public class AddXptoCommandValidator : CommandValidator<AddXptoCommand>
    {
        public AddXptoCommandValidator()
        {
            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);
        }
    }
}
