using System;

namespace GenericImporter.Domain.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ImportClassAttribute : Attribute
    {
        public Type ClassToUse { get; set; }
        public string MethodToUse { get; set; }
    }
}
