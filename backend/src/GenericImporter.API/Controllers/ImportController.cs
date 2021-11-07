using GenericImporter.Application.DataTransferObjects.ImportDTOs;
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
    [Route("api/import")]
    public class ImportController : BaseController
    {
        private readonly IImportAppService _importAppService;

        public ImportController(INotificationHandler<DomainNotification> notifications,
                                IImportAppService importAppService)
            : base(notifications)
        {
            _importAppService = importAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ImportDto>> Get()
        {
            return await _importAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ImportDto> GetById(Guid id)
        {
            return await _importAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddImportDto addImportDto)
        {
            await _importAppService.Add(addImportDto);
            return Response();
        }
    }
}
