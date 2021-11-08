using AutoMapper;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Commands.XptoCommands;
using Something.Domain.Entities;

namespace Something.Application.AutoMapper
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateXptoMap();
        }

        private void CreateXptoMap()
        {
            CreateMap<AddXptoDto, AddXptoCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Xpto() { Name = s.Name }));
        }
    }
}
