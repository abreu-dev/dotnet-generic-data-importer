using Core.Application.DataTransferObjects;
using GenericImporter.Service.Attributes;
using Something.Application.Interfaces;

namespace Something.Application.DataTransferObjects.XptoDtos
{
    [ImportClass(Class = typeof(IXptoAppService), Method = "Add")]
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name="Name")]
        public string Name { get; set; }
    }
}
