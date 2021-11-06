using AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Entities;

namespace GenericImporter.Application.AutoMapper
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateXptoMap();
            CreateImportLayoutMap();
        }

        private void CreateXptoMap()
        {
            CreateMap<AddXptoDto, AddXptoCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Xpto() { Name = s.Name }));
        }

        private void CreateImportLayoutMap()
        {
            CreateMap<AddImportLayoutDto, AddImportLayoutCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new ImportLayout() { Name = s.Name }));
        }
    }
}
