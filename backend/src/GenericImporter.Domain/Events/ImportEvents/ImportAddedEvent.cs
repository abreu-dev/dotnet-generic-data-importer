using GenericImporter.Domain.Core.Events;
using System;

namespace GenericImporter.Domain.Events.ImportEvents
{
    public class ImportAddedEvent : Event
    {
        public ImportAddedEvent(Guid aggregateId) : base(aggregateId) { }
    }
}
