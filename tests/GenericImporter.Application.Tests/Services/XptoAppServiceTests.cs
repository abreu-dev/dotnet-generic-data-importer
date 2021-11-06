using AutoMapper;
using GenericImporter.Application.DataTransferObjects.XptoDTOs;
using GenericImporter.Application.Interfaces;
using GenericImporter.Application.Services;
using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Application.Tests.Services
{
    public class XptoAppServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly IXptoAppService _xptoAppService;

        public XptoAppServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _xptoAppService = new XptoAppService(
                _mockMapper.Object,
                _mockMediatorHandler.Object,
                new Mock<IXptoRepository>().Object);
        }

        [Fact(DisplayName = "Add_ShouldPublishAddXptoCommand")]
        [Trait("AppService", "Xpto")]
        public async Task Add_ShouldPublishAddXptoCommand()
        {
            // Arrange
            var addXptoDTO = new AddXptoDTO()
            {
                Name = "Xpto"
            };

            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = addXptoDTO.Name
                }
            };

            _mockMapper.Setup(e => e.Map<AddXptoCommand>(It.Is<AddXptoDTO>(s => s.Equals(addXptoDTO)))).Returns(command);

            // Act
            await _xptoAppService.Add(addXptoDTO);

            // Assert
            _mockMediatorHandler.Verify(e => e.SendCommand(It.Is<AddXptoCommand>(s => s.Equals(command))), Times.Once);
        }
    }
}
