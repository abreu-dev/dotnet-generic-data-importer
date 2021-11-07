using System;

namespace GenericImporter.Domain.Entities
{
    public class ImportItem
    {
        public Guid Id { get; set; }
        public Guid ImportId { get; set; }
        public string ImportFileLine { get; set; }

        // EF Rel.
        public virtual Import Import { get; set; }
    }
}
