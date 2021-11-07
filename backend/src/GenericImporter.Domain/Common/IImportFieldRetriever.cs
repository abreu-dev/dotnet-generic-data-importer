using GenericImporter.Domain.Enums;
using System.Reflection;

namespace GenericImporter.Domain.Common
{
    public interface IImportFieldRetriever
    {
        PropertyInfo[] GetProperties(ImportLayoutEntity importLayoutEntity);
    }
}
