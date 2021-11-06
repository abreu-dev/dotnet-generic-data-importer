using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.XptoDTOs
{
    public class UpdateXptoDTO : DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
