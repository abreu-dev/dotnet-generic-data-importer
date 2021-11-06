using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class ImportLayoutDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
