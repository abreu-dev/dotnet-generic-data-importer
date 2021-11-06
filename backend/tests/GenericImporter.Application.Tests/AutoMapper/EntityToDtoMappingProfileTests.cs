using AutoMapper;
using GenericImporter.Application.AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Entities;
using System;
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
    }
}
