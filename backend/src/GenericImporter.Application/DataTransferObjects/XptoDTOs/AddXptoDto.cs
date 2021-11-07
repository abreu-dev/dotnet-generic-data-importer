using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Domain.Common;

namespace GenericImporter.Application.DataTransferObjects.XptoDtos
{
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name = "Name22")]
        public string Name { get; set; }
    }
}
