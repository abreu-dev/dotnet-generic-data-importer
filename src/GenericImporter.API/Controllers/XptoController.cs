using GenericImporter.Application.DataTransferObjects.XptoDTOs;
using GenericImporter.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericImporter.API.Controllers
{
    public class XptoController : ApiController
    {
        private readonly IXptoAppService _xptoAppService;

        public XptoController(IXptoAppService xptoAppService)
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
            return Ok();
        }
    }
}
