using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.XptoDtos
{
    public class UpdateXptoDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
