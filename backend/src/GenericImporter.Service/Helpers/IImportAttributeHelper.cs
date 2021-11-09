using GenericImporter.Service.Attributes;
using System;
using System.Reflection;

namespace GenericImporter.Service.Helpers
{
    public interface IImportAttributeHelper
    {
        PropertyInfo FindClassPropertyByName(Type type, string name);
        ImportClassAttribute GetImportClassAttribute(Type type);
        ImportFieldAttribute GetImportFieldAttribute(PropertyInfo propertyInfo);
    }
}
