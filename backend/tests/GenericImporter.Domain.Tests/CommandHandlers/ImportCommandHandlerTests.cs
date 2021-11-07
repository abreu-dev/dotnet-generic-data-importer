using GenericImporter.Domain.CommandHandlers;
using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Interfaces;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Domain.Tests.CommandHandlers
{
    public class ImportCommandHandlerTests
    {
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly Mock<IImportLayoutRepository> _mockImportLayoutRepository;
        private readonly Mock<IImportRepository> _mockImportRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ImportCommandHandler _importCommandHandler;

        public ImportCommandHandlerTests()
        {
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockImportLayoutRepository = new Mock<IImportLayoutRepository>();
            _mockImportRepository = new Mock<IImportRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _importCommandHandler = new ImportCommandHandler(
                _mockMediatorHandler.Object,
                new Mock<DomainNotificationHandler>().Object,
                _mockImportLayoutRepository.Object,
                _mockImportRepository.Object);
        }

        [Fact(DisplayName = "Handle_AddImportCommand_ShouldPublishDomainNotification_WhenInvalidCommand")]
        [Trait("CommandHandler", "Import")]
        public async Task Handle_AddImportCommand_ShouldPublishDomainNotification_WhenInvalidCommand()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.Empty,
                    ImportItems = new List<ImportItem>()
                    {
                        new ImportItem()
                        {
                            ImportFileLine = "ImportFileLine"
                        }
                    }
                }
            };

            // Act
            await _importCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == DomainMessages.RequiredField.Format("ImportLayoutId").Message)), 
                Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportCommand_ShouldPublishDomainNotification_WhenImportLayoutNotFound")]
        [Trait("CommandHandler", "Import")]
        public async Task Handle_AddImportCommand_ShouldPublishDomainNotification_WhenImportLayoutNotFound()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.NewGuid(),
                    ImportItems = new List<ImportItem>()
                    {
                        new ImportItem()
                        {
                            ImportFileLine = "ImportFileLine"
                        }
                    }
                }
            };

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>()))
                .ReturnsAsync(new List<ImportLayout>());

            // Act
            await _importCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == DomainMessages.NotFound.Format("ImportLayout").Message)),
                Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportCommand_ShouldAddAndCommit_WhenValid")]
        [Trait("CommandHandler", "Import")]
        public async Task Handle_AddImportCommand_ShouldAddAndCommit_WhenValid()
        {
            // Arrange
            var command = new AddImportCommand()
            {
                Entity = new Import()
                {
                    ImportLayoutId = Guid.NewGuid(),
                    ImportItems = new List<ImportItem>()
                    {
                        new ImportItem()
                        {
                            ImportFileLine = "ImportFileLine"
                        }
                    }
                }
            };

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>()))
                .ReturnsAsync(new List<ImportLayout>() { new ImportLayout() { Id = command.Entity.ImportLayoutId } });
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);
            _mockImportRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _importCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockImportRepository.Verify(e => e.Add(It.Is<Import>(s => s.Equals(command.Entity))), Times.Once);
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }
    }
}
