using GenericImporter.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace GenericImporter.Domain.Entities
{
    public class Import : Entity
    {
        public Guid ImportLayoutId { get; set; }
        public DateTime Date { get; set; }

        // EF Rel.
        public virtual ImportLayout ImportLayout { get; set; }
        public IEnumerable<ImportItem> ImportItems { get; set; }
    }
}
