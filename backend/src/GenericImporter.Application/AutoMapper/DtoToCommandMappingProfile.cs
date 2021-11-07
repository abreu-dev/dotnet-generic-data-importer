using AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Entities;
using System.Linq;

namespace GenericImporter.Application.AutoMapper
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateXptoMap();
            CreateImportLayoutMap();
            CreateImportMap();
        }

        private void CreateXptoMap()
        {
            CreateMap<AddXptoDto, AddXptoCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Xpto() { Name = s.Name }));
        }

        private void CreateImportLayoutMap()
        {
            CreateMap<AddImportLayoutDto, AddImportLayoutCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new ImportLayout()))
                .ForPath(d => d.Entity.Name, o => o.MapFrom(s => s.Name))
                .ForPath(d => d.Entity.Separator, o => o.MapFrom(s => s.Separator))
                .ForPath(d => d.Entity.ImportLayoutEntity, o => o.MapFrom(s => s.ImportLayoutEntity))
                .ForPath(d => d.Entity.ImportLayoutColumns, o => o.MapFrom(s => s.ImportLayoutColumns.Select(s2 => new ImportLayoutColumn 
                {
                    Name = s2.Name,
                    Position = s2.Position
                })));
        }

        private void CreateImportMap()
        {
            CreateMap<AddImportDto, AddImportCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Import()))
                .ForPath(d => d.Entity.ImportLayoutId, o => o.MapFrom(s => s.ImportLayoutId));
        }
    }
}
