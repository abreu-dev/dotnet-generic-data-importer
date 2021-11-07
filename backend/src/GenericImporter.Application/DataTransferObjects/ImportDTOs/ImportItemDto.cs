using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportDTOs
{
    public class ImportItemDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string ImportFileLine { get; set; }
        public bool Processed { get; set; }
        public string Error { get; set; }
    }
}
