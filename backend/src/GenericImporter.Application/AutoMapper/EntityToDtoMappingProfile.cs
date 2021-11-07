using AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Xpto, XptoDto>();
            CreateMap<ImportLayout, ImportLayoutDto>();
            CreateMap<ImportLayoutColumn, ImportLayoutColumnDto>();
            CreateMap<Import, ImportDto>();
            CreateMap<ImportItem, ImportItemDto>();
        }
    }
}
