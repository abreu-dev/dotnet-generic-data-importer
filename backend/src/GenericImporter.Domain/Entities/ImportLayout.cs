using GenericImporter.Domain.Core.Entities;
using GenericImporter.Domain.Enums;
using System.Collections.Generic;

namespace GenericImporter.Domain.Entities
{
    public class ImportLayout : Entity
    {
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutEntity ImportLayoutEntity { get; set; }

        // EF Rel.
        public IEnumerable<ImportLayoutColumn> ImportLayoutColumns { get; set; }
    }
}
