using AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
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
