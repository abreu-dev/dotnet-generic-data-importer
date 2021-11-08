using AutoMapper;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Entities;

namespace Something.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Xpto, XptoDto>();
        }
    }
}
