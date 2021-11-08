using AutoMapper;
using Core.Application.Services;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Application.Interfaces;
using Something.Domain.Commands.XptoCommands;
using Core.Domain.Mediator;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using System.Threading.Tasks;

namespace Something.Application.Services
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
