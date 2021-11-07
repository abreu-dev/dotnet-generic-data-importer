using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class ImportLayoutColumnDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
