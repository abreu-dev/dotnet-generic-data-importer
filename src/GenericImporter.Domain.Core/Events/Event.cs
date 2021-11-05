using MediatR;
using System;

namespace GenericImporter.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        protected Event(Guid aggregateId) : base(aggregateId) { }
    }
}
