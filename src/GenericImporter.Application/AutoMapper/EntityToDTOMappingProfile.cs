using AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDTOs;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<Xpto, XptoDTO>();
        }
    }
}
