using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.XptoDTOs
{
    public class UpdateXptoDTO : IDataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
