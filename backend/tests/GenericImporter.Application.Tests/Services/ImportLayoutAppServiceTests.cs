using AutoMapper;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Application.Services;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using GenericImporter.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Application.Tests.Services
{
    public class ImportLayoutAppServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly IImportLayoutAppService _importLayoutAppService;

        public ImportLayoutAppServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _importLayoutAppService = new ImportLayoutAppService(
                _mockMapper.Object,
                _mockMediatorHandler.Object,
                new Mock<IImportLayoutRepository>().Object);
        }

        [Fact(DisplayName = "Add_ShouldPublishAddImportLayoutCommand")]
        [Trait("AppService", "ImportLayout")]
        public async Task Add_ShouldPublishAddImportLayoutCommand()
        {
            // Arrange
            var addImportLayoutDto = new AddImportLayoutDto()
            {
                Name = "Name",
                Separator = ";",
                ImportLayoutEntity = ImportLayoutEntity.Xpto,
                ImportLayoutColumns = new List<AddImportLayoutColumnDto>()
                {
                    new AddImportLayoutColumnDto()
                    {
                        Name = "Name",
                        Position = 1
                    }
                }
            };

            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = "Name",
                    Separator = ";",
                    ImportLayoutEntity = ImportLayoutEntity.Xpto,
                    ImportLayoutColumns = new List<ImportLayoutColumn>()
                    {
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 1
                        }
                    }
                }
            };

            _mockMapper.Setup(e => e.Map<AddImportLayoutCommand>(It.Is<AddImportLayoutDto>(s => s.Equals(addImportLayoutDto)))).Returns(command);

            // Act
            await _importLayoutAppService.Add(addImportLayoutDto);

            // Assert
            _mockMediatorHandler.Verify(e => e.SendCommand(It.Is<AddImportLayoutCommand>(s => s.Equals(command))), Times.Once);
        }
    }
}
