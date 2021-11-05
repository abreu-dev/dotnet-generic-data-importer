using AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDTOs;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateXptoMap();
        }

        private void CreateXptoMap()
        {
            CreateMap<AddXptoDTO, AddXptoCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Xpto() { Name = s.Name }));
        }
    }
}
