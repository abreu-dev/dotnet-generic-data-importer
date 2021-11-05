using System;

namespace GenericImporter.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
    }
}
