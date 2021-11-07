﻿using AutoMapper;
using GenericImporter.Application.Core.Services;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using System.Threading.Tasks;

namespace GenericImporter.Application.Services
{
    public class ImportLayoutAppService : AppService<ImportLayoutDto, AddImportLayoutDto, ImportLayout>,
        IImportLayoutAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ImportLayoutAppService(IMapper mapper,
                                      IMediatorHandler mediator,
                                      IImportLayoutRepository importLayoutRepository)
            : base(mapper, importLayoutRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task Add(AddImportLayoutDto addImportLayoutDto)
        {
            await _mediator.SendCommand(_mapper.Map<AddImportLayoutCommand>(addImportLayoutDto));
        }
    }
}