﻿using GenericImporter.Application.Core.DataTransferObjects;
using System;

namespace GenericImporter.Application.DataTransferObjects.ImportDTOs
{
    public class AddImportDto : DataTransferObject
    {
        public Guid ImportLayoutId { get; set; }
        public string ImportFileLines { get; set; }
    }
}
