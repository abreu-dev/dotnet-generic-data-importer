using AutoMapper;
using GenericImporter.Application.Core.Services;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using System.Threading.Tasks;

namespace GenericImporter.Application.Services
{
    public class ImportAppService : AppService<ImportDto, AddImportDto, Import>,
        IImportAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ImportAppService(IMapper mapper,
                                IMediatorHandler mediator,
                                IImportRepository importRepository)
            : base(mapper, importRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task Add(AddImportDto addImportDto)
        {
            await _mediator.SendCommand(_mapper.Map<AddImportCommand>(addImportDto));
        }
    }
}
