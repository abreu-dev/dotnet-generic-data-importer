using AutoMapper;
using GenericImporter.Application.AutoMapper;
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
    }
}
