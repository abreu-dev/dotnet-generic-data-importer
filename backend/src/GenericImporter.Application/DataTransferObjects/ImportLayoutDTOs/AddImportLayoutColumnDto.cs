using GenericImporter.Application.Core.DataTransferObjects;

namespace GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class AddImportLayoutColumnDto : DataTransferObject
    {
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
