using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Application.Interfaces;
using Core.Domain.Notifications;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericImporter.API.Controllers
{
    public class XptoController : BaseController
    {
        private readonly IXptoAppService _xptoAppService;

        public XptoController(INotificationHandler<DomainNotification> notifications, 
                              IXptoAppService xptoAppService) 
            : base(notifications)
        {
            _xptoAppService = xptoAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<XptoDto>> Get()
        {
            return await _xptoAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<XptoDto> GetById(Guid id)
        {
            return await _xptoAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddXptoDto addXptoDto)
        {
            await _xptoAppService.Add(addXptoDto);
            return Response();
        }
    }
}
