using GenericImporter.Domain.Common;
using GenericImporter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenericImporter.Application.Common
{
    public class ImportFieldRetriever : IImportFieldRetriever
    {
        public PropertyInfo[] GetProperties(ImportLayoutEntity importLayoutEntity)
        {
            var dtoType = Type.GetType(importLayoutEntity.GetDescription());
            if (dtoType == null)
            {
                return new List<PropertyInfo>().ToArray();
            }
            return dtoType.GetProperties();
        }
    }
}
