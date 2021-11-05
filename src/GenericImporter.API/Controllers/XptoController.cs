﻿using GenericImporter.Application.DataTransferObjects.XptoDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Web.Core.Controllers;
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
        public async Task<IEnumerable<XptoDTO>> Get()
        {
            return await _xptoAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<XptoDTO> Get(Guid id)
        {
            return await _xptoAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddXptoDTO addXptoDTO)
        {
            await _xptoAppService.Add(addXptoDTO);
            return Response();
        }
    }
}
