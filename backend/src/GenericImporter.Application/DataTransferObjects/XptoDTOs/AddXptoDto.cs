using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Common;
using System;

namespace GenericImporter.Application.DataTransferObjects.XptoDtos
{
    [ImportClass(ClassToUse = typeof(IXptoAppService),
                 MethodToUse = "Add")]
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name = "Name")]
        public string Name { get; set; }

        [ImportField(Name = "Date")]
        public DateTime Date { get; set; }

        [ImportField(Name = "Version")]
        public int Version { get; set; }

        [ImportField(Name = "Value")]
        public double Value { get; set; }
    }
}
