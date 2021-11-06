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
        }
    }
}
