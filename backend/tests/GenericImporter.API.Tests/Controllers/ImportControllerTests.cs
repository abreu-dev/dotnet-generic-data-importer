using GenericImporter.API.Controllers;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Core.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.API.Tests.Controllers
{
    public class ImportControllerTests
    {
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly Mock<IImportAppService> _mockImportAppService;
        private readonly ImportController _importController;

        public ImportControllerTests()
        {
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _mockImportAppService = new Mock<IImportAppService>();
            _importController = new ImportController(
                _mockNotifications.Object,
                _mockImportAppService.Object);
        }

        [Fact(DisplayName = "Get_ShouldReturnEmptyImportDtoList_WhenAppServiceReturnsEmptyDtoList")]
        [Trait("Controllers", "Import")]
        public async Task Get_ShouldReturnEmptyImportDtoList_WhenAppServiceReturnsEmptyDtoList()
        {
            // Arrange
            _mockImportAppService.Setup(e => e.GetAll()).ReturnsAsync(new List<ImportDto>());

            // Act
            var result = await _importController.Get();

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "Get_ShouldReturnImportDtoList_WhenAppServiceReturnsDtoList")]
        [Trait("Controllers", "Import")]
        public async Task Get_ShouldReturnImportDtoList_WhenAppServiceReturnsDtoList()
        {
            // Arrange
            var importDtoOne = new ImportDto();
            var importDtoTwo = new ImportDto();
            var importList = new List<ImportDto>() { importDtoOne, importDtoTwo };
            _mockImportAppService.Setup(e => e.GetAll()).ReturnsAsync(importList);

            // Act
            var result = await _importController.Get();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(importList, result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenAppServiceReturnsNull")]
        [Trait("Controllers", "Import")]
        public async Task GetById_ShouldReturnNull_WhenAppServiceReturnsNull()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockImportAppService.Setup(e => e.GetById(id)).ReturnsAsync((ImportDto)null);

            // Act
            var result = await _importController.GetById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnDto_WhenAppServiceReturnsDto")]
        [Trait("Controllers", "Import")]
        public async Task GetById_ShouldReturnDto_WhenAppServiceReturnsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var importDto = new ImportDto();
            _mockImportAppService.Setup(e => e.GetById(id)).ReturnsAsync(importDto);

            // Act
            var result = await _importController.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(importDto, result);
        }

        [Fact(DisplayName = "Add_ShouldCallAppServiceAddAndReturnResponse")]
        [Trait("Controllers", "Import")]
        public async Task Add_ShouldCallAppServiceAddAndReturnResponse()
        {
            // Arrange
            var addImportDto = new AddImportDto();

            // Act
            var result = await _importController.Add(addImportDto);

            // Assert
            _mockImportAppService.Verify(e => e.Add(addImportDto), Times.Once);
            Assert.NotNull(result);
        }
    }
}
