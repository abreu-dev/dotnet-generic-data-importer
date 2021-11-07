using System;

namespace GenericImporter.Domain.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ImportFieldAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
