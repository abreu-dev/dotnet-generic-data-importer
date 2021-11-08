using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Common;

namespace GenericImporter.Application.DataTransferObjects.XptoDtos
{
    [ImportClass(ServiceToUse = typeof(IXptoAppService))]
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name = "Name")]
        public string Name { get; set; }
    }
}
