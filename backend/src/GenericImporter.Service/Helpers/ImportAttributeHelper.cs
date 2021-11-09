using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenericImporter.Service.Helpers
{
    public class ImportAttributeHelper : IImportAttributeHelper
    {
        public PropertyInfo FindClassPropertyByName(Type type, string name)
        {
            if (type == null)
            {
                return null;
            }

            var foundedProperties = new List<PropertyInfo>();

            foreach (var property in type.GetProperties())
            {
                var fieldAttribute = GetImportFieldAttribute(property);

                if (fieldAttribute != null && fieldAttribute.Name == name)
                {
                    foundedProperties.Add(property);
                }
            }

            if (foundedProperties.Count > 1)
            {
                throw new ImporterException("Duplicated ImportFieldAttributeName in class.");
            }

            return foundedProperties.SingleOrDefault();
        }

        public ImportClassAttribute GetImportClassAttribute(Type type)
        {
            if (type == null)
            {
                return null;
            }

            var customAttribute = type.GetCustomAttributes(typeof(ImportClassAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportClassAttribute)customAttribute;
            }

            return null;
        }

        public ImportFieldAttribute GetImportFieldAttribute(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                return null;
            }

            var customAttribute = propertyInfo.GetCustomAttributes(typeof(ImportFieldAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportFieldAttribute)customAttribute;
            }

            return null;
        }
    }
}
