using FluentValidation.Results;
using GenericImporter.Domain.Core.Events;
using MediatR;
using System;

namespace GenericImporter.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest<Unit>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected Command(Guid aggregateId) : base(aggregateId) { }

        public abstract bool IsValid();
    }
}
