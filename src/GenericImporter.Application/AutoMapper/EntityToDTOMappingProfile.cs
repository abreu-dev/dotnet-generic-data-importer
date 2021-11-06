using AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Xpto, XptoDto>();
        }
    }
}
