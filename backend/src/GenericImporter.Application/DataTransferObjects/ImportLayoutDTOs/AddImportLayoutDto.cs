using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Domain.Enums;
using System.Collections.Generic;

namespace GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class AddImportLayoutDto : DataTransferObject
    {
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutEntity ImportLayoutEntity { get; set; }
        public IEnumerable<AddImportLayoutColumnDto> ImportLayoutColumns { get; set; }
    }
}
