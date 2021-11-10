using AutoMapper;
using Core.Application.Services;
using Core.Domain.Common;
using Core.Domain.Mediator;
using GenericImporter.Service.Extensions;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Application.Interfaces;
using Something.Domain.Commands.XptoCommands;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Something.Application.Services
{
    public class XptoAppService : AppService<XptoDto, AddXptoDto, Xpto>,
        IXptoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IServiceProvider _serviceProvider;

        public XptoAppService(IMapper mapper,
                              IMediatorHandler mediator,
                              IXptoRepository xptoRepository,
                              IServiceProvider serviceProvider)
            : base(mapper, xptoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

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

        public async Task Import(string file)
        {
            var importColumns = new List<string>() { "Name" };
            var importObjectType = typeof(AddXptoDto);
            var classAttribute = importObjectType.GetImportClassAttribute();
            var service = _serviceProvider.GetService(classAttribute.Class);

            foreach (var item in file.ReadLines())
            {
                var splitted = item.Split(";");

                var instance = importObjectType.CreateInstance();

                foreach (var column in importColumns.Select((value, index) => (value, index)))
                {
                    var property = importObjectType.GetPropertyByImportName(column.value);
                    property.SetValueByString(instance, splitted[column.index]);
                }

                service.CallMethod(classAttribute.Method, instance);
            }
        }
    }
}
