using AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Application.Services;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Application.Tests.Services
{
    public class ImportAppServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly IImportAppService _importAppService;

        public ImportAppServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _importAppService = new ImportAppService(
                _mockMapper.Object,
                _mockMediatorHandler.Object,
                new Mock<IImportRepository>().Object);
        }

        [Fact(DisplayName = "Add_ShouldPublishAddImportCommand")]
        [Trait("AppService", "Import")]
        public async Task Add_ShouldPublishAddImportCommand()
        {
            // Arrange
            var addImportDto = new AddImportDto()
            {
                ImportLayoutId = Guid.NewGuid()
            };

            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.NewGuid()
                }
            };

            _mockMapper.Setup(e => e.Map<AddImportCommand>(It.Is<AddImportDto>(s => s.Equals(addImportDto)))).Returns(command);

            // Act
            await _importAppService.Add(addImportDto);

            // Assert
            _mockMediatorHandler.Verify(e => e.SendCommand(It.Is<AddImportCommand>(s => s.Equals(command))), Times.Once);
        }
    }
}
