using FluentValidation;
using GenericImporter.Domain.Core.Commands;

namespace GenericImporter.Domain.Core.Validators
{
    public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command
    {
        protected CommandValidator() { }
    }
}
