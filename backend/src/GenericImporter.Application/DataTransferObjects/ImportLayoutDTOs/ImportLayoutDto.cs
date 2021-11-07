using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Domain.Enums;
using System;
using System.Collections.Generic;

namespace GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class ImportLayoutDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutEntity ImportLayoutEntity { get; set; }
        public IEnumerable<ImportLayoutColumnDto> ImportLayoutColumns { get; set; }
    }
}
