using AutoMapper;
using GenericImporter.Application.AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GenericImporter.Application.Tests.AutoMapper
{
    public class DtoToCommandMappingProfileTests
    {
        private readonly IMapper _mapper;

        public DtoToCommandMappingProfileTests()
        {
            _mapper = new MapperConfiguration(p => p.AddProfile(new DtoToCommandMappingProfile())).CreateMapper();
        }

        [Fact(DisplayName = "Map_ShouldMapAddXptoDtoToAddXptoCommand")]
        [Trait("AutoMapper", "DtoToCommandMappingProfile")]
        public void Map_ShouldMapAddXptoDtoToAddXptoCommand()
        {
            // Arrange
            var addXptoDto = new AddXptoDto()
            {
                Name = "Xpto"
            };

            // Act
            var result = _mapper.Map<AddXptoCommand>(addXptoDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addXptoDto.Name, result.Entity.Name);
        }

        [Fact(DisplayName = "Map_ShouldMapAddImportLayoutDtoToAddImportLayoutCommand")]
        [Trait("AutoMapper", "DtoToCommandMappingProfile")]
        public void Map_ShouldMapAddImportLayoutDtoToAddImportLayoutCommand()
        {
            // Arrange
            var addImportLayoutDto = new AddImportLayoutDto()
            {
                Name = "Name",
                Separator = ";",
                ImportLayoutEntity = ImportLayoutEntity.Xpto,
                ImportLayoutColumns = new List<AddImportLayoutColumnDto>()
                {
                    new AddImportLayoutColumnDto()
                    {
                        Name = "Name",
                        Position = 1
                    }
                }
            };

            // Act
            var result = _mapper.Map<AddImportLayoutCommand>(addImportLayoutDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addImportLayoutDto.Name, result.Entity.Name);
            Assert.Equal(addImportLayoutDto.Separator, result.Entity.Separator);
            Assert.Equal(addImportLayoutDto.ImportLayoutEntity, result.Entity.ImportLayoutEntity);
            Assert.Equal(addImportLayoutDto.ImportLayoutColumns.Single().Name, result.Entity.ImportLayoutColumns.Single().Name);
            Assert.Equal(addImportLayoutDto.ImportLayoutColumns.Single().Position, result.Entity.ImportLayoutColumns.Single().Position);
        }

        [Fact(DisplayName = "Map_ShouldMapAddImportDtoToAddImportCommand")]
        [Trait("AutoMapper", "DtoToCommandMappingProfile")]
        public void Map_ShouldMapAddImportDtoToAddImportCommand()
        {
            // Arrange
            var importFileLine = "ImportFileLine";
            var addImportDto = new AddImportDto()
            {
                ImportLayoutId = Guid.NewGuid(),
                ImportFileLines = new StringBuilder()
                    .AppendLine(importFileLine)
                    .ToString()
            };

            // Act
            var result = _mapper.Map<AddImportCommand>(addImportDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addImportDto.ImportLayoutId, result.Entity.ImportLayoutId);
            Assert.Equal(importFileLine, result.Entity.ImportItems.Single().ImportFileLine);
        }
    }
}
