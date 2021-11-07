using GenericImporter.Domain.Common;
using GenericImporter.Domain.Core.Entities;

namespace GenericImporter.Domain.Entities
{
    public class Xpto : Entity
    {
        [ImportField(Name = "Name")]
        public string Name { get; set; }
    }
}
