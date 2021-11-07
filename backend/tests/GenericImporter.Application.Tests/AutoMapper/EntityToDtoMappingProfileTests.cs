using AutoMapper;
using GenericImporter.Application.AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericImporter.Application.Tests.AutoMapper
{
    public class EntityToDtoMappingProfileTests
    {
        private readonly IMapper _mapper;

        public EntityToDtoMappingProfileTests()
        {
            _mapper = new MapperConfiguration(p => p.AddProfile(new EntityToDtoMappingProfile())).CreateMapper();
        }

        [Fact(DisplayName = "Map_ShouldMapXptoToXptoDto")]
        [Trait("AutoMapper", "EntityToDtoMappingProfile")]
        public void Map_ShouldMapXptoToXptoDto()
        {
            // Arrange
            var xpto = new Xpto()
            {
                Id = Guid.NewGuid(),
                Code = 1,
                Name = "Xpto"
            };

            // Act
            var result = _mapper.Map<XptoDto>(xpto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(xpto.Id, result.Id);
            Assert.Equal(xpto.Code, result.Code);
            Assert.Equal(xpto.Name, result.Name);
        }

        [Fact(DisplayName = "Map_ShouldMapImportLayoutToImportLayoutDto")]
        [Trait("AutoMapper", "EntityToDtoMappingProfile")]
        public void Map_ShouldMapImportLayoutToImportLayoutDto()
        {
            // Arrange
            var importLayout = new ImportLayout()
            {
                Name = "Name",
                Separator = ";",
                ImportLayoutEntity = ImportLayoutEntity.Xpto,
                ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
            };

            // Act
            var result = _mapper.Map<ImportLayoutDto>(importLayout);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(importLayout.Id, result.Id);
            Assert.Equal(importLayout.Code, result.Code);
            Assert.Equal(importLayout.Name, result.Name);
            Assert.Equal(importLayout.Separator, result.Separator);
            Assert.Equal(importLayout.ImportLayoutEntity, result.ImportLayoutEntity);
            Assert.Equal(importLayout.ImportLayoutColumns.Single().Name, result.ImportLayoutColumns.Single().Name);
            Assert.Equal(importLayout.ImportLayoutColumns.Single().Position, result.ImportLayoutColumns.Single().Position);
        }

        [Fact(DisplayName = "Map_ShouldMapImportToImportDto")]
        [Trait("AutoMapper", "EntityToDtoMappingProfile")]
        public void Map_ShouldMapImportToImportDto()
        {
            // Arrange
            var import = new Import()
            {
                ImportLayoutId = Guid.NewGuid(),
                Date = DateTime.Now,
                ImportLayout = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            // Act
            var result = _mapper.Map<ImportDto>(import);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(import.Id, result.Id);
            Assert.Equal(import.Code, result.Code);
            Assert.Equal(import.ImportLayout.Id, result.ImportLayout.Id);
            Assert.Equal(import.ImportLayout.Code, result.ImportLayout.Code);
            Assert.Equal(import.ImportLayout.Name, result.ImportLayout.Name);
            Assert.Equal(import.ImportLayout.Separator, result.ImportLayout.Separator);
            Assert.Equal(import.ImportLayout.ImportLayoutEntity, result.ImportLayout.ImportLayoutEntity);
            Assert.Equal(import.ImportLayout.ImportLayoutColumns.Single().Name, result.ImportLayout.ImportLayoutColumns.Single().Name);
            Assert.Equal(import.ImportLayout.ImportLayoutColumns.Single().Position, result.ImportLayout.ImportLayoutColumns.Single().Position);
            Assert.Equal(import.Date, result.Date);
        }
    }
}
