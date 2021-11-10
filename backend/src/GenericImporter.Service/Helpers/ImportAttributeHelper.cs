using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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

    public static class TypeExtensions
    {
        public static PropertyInfo GetPropertyByImportName(this Type type, string name)
        {
            var foundedProperties = new List<PropertyInfo>();

            foreach (var property in type.GetProperties())
            {
                var attribute = property.GetImportAttribute();
                if (attribute != null && attribute.Name == name)
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

        public static ImportClassAttribute GetImportClassAttribute(this Type type)
        {
            var customAttribute = type.GetCustomAttributes(typeof(ImportClassAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportClassAttribute)customAttribute;
            }

            return null;
        }

        public static object CreateInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static MethodInfo GetMethodOfInterface(this Type type, string name)
        {
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
        }
    }

    public static class PropertyInfoExtensions
    {
        public static ImportFieldAttribute GetImportAttribute(this PropertyInfo propertyInfo)
        {
            var customAttribute = propertyInfo.GetCustomAttributes(typeof(ImportFieldAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportFieldAttribute)customAttribute;
            }

            return null;
        }

        public static void SetValueByString(this PropertyInfo propertyInfo, object instance, string value)
        {
            propertyInfo.SetValue(instance, value);
        }
    }

    public static class ObjectExtensions
    {
        public static void CallMethod(this object service, string methodName, object parameter)
        {
            var method = service.GetType().GetMethodOfInterface(methodName);
            var convertedParameter = Convert.ChangeType(parameter, parameter.GetType());
            method.Invoke(service, new object[] { convertedParameter });
        }
    }
}
