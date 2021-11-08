using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Common;

namespace GenericImporter.Application.DataTransferObjects.XptoDtos
{
    [ImportClass(ClassToUse = typeof(IXptoAppService),
                 MethodToUse = "Add")]
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name = "Name")]
        public string Name { get; set; }
    }
}
