using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportDTOs
{
    public class ImportDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public ImportLayoutDto ImportLayout { get; set; }
        public DateTime Date { get; set; }
    }
}
