using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Domain.Common;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportDTOs
{
    public class AddImportDto : DataTransferObject
    {
        [ImportField(Name = "ImportLayoutId")]
        public Guid ImportLayoutId { get; set; }
    }
}
