using GenericImporter.Service.Attributes;
using System.Linq;
using System.Reflection;

namespace GenericImporter.Service.Extensions
{
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
}
