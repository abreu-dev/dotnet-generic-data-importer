using AutoMapper;
using GenericImporter.Application.Core.Services;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using System.Threading.Tasks;

namespace GenericImporter.Application.Services
{
    public class XptoAppService : AppService<XptoDto, AddXptoDto, Xpto>,
        IXptoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public XptoAppService(IMapper mapper,
                              IMediatorHandler mediator,
                              IXptoRepository xptoRepository)
            : base(mapper, xptoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task Add(AddXptoDto addXptoDto)
        {
            await _mediator.SendCommand(_mapper.Map<AddXptoCommand>(addXptoDto));
        }
    }
}
