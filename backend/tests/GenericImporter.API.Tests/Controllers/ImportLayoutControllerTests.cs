using GenericImporter.API.Controllers;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;
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
    public class ImportLayoutControllerTests
    {
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly Mock<IImportLayoutAppService> _mockImportLayoutAppService;
        private readonly ImportLayoutController _importLayoutController;

        public ImportLayoutControllerTests()
        {
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _mockImportLayoutAppService = new Mock<IImportLayoutAppService>();
            _importLayoutController = new ImportLayoutController(
                _mockNotifications.Object,
                _mockImportLayoutAppService.Object);
        }

        [Fact(DisplayName = "Get_ShouldReturnEmptyImportLayoutDtoList_WhenAppServiceReturnsEmptyDtoList")]
        [Trait("Controllers", "ImportLayout")]
        public async Task Get_ShouldReturnEmptyImportLayoutDtoList_WhenAppServiceReturnsEmptyDtoList()
        {
            // Arrange
            _mockImportLayoutAppService.Setup(e => e.GetAll()).ReturnsAsync(new List<ImportLayoutDto>());

            // Act
            var result = await _importLayoutController.Get();

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "Get_ShouldReturnImportLayoutDtoList_WhenAppServiceReturnsDtoList")]
        [Trait("Controllers", "ImportLayout")]
        public async Task Get_ShouldReturnImportLayoutDtoList_WhenAppServiceReturnsDtoList()
        {
            // Arrange
            var importLayoutDtoOne = new ImportLayoutDto();
            var importLayoutDtoTwo = new ImportLayoutDto();
            var importLayoutList = new List<ImportLayoutDto>() { importLayoutDtoOne, importLayoutDtoTwo };
            _mockImportLayoutAppService.Setup(e => e.GetAll()).ReturnsAsync(importLayoutList);

            // Act
            var result = await _importLayoutController.Get();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(importLayoutList, result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenAppServiceReturnsNull")]
        [Trait("Controllers", "ImportLayout")]
        public async Task GetById_ShouldReturnNull_WhenAppServiceReturnsNull()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockImportLayoutAppService.Setup(e => e.GetById(id)).ReturnsAsync((ImportLayoutDto)null);

            // Act
            var result = await _importLayoutController.GetById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnDto_WhenAppServiceReturnsDto")]
        [Trait("Controllers", "ImportLayout")]
        public async Task GetById_ShouldReturnDto_WhenAppServiceReturnsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var importLayoutDto = new ImportLayoutDto();
            _mockImportLayoutAppService.Setup(e => e.GetById(id)).ReturnsAsync(importLayoutDto);

            // Act
            var result = await _importLayoutController.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(importLayoutDto, result);
        }

        [Fact(DisplayName = "Add_ShouldCallAppServiceAddAndReturnResponse")]
        [Trait("Controllers", "ImportLayout")]
        public async Task Add_ShouldCallAppServiceAddAndReturnResponse()
        {
            // Arrange
            var addImportLayoutDto = new AddImportLayoutDto();

            // Act
            var result = await _importLayoutController.Add(addImportLayoutDto);

            // Assert
            _mockImportLayoutAppService.Verify(e => e.Add(addImportLayoutDto), Times.Once);
            Assert.NotNull(result);
        }
    }
}
