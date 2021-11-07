using GenericImporter.Domain.CommandHandlers;
using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Common;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Interfaces;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using GenericImporter.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Domain.Tests.CommandHandlers
{
    public class ImportLayoutCommandHandlerTests
    {
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly Mock<IImportLayoutRepository> _mockImportLayoutRepository;
        private readonly Mock<IImportFieldRetriever> _mockImportFieldRetriever;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ImportLayoutCommandHandler _importLayoutCommandHandler;

        public ImportLayoutCommandHandlerTests()
        {
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockImportLayoutRepository = new Mock<IImportLayoutRepository>();
            _mockImportFieldRetriever = new Mock<IImportFieldRetriever>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _importLayoutCommandHandler = new ImportLayoutCommandHandler(
                _mockMediatorHandler.Object,
                new Mock<DomainNotificationHandler>().Object,
                _mockImportLayoutRepository.Object,
                _mockImportFieldRetriever.Object);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenInvalidCommand")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenInvalidCommand()
        {
            // Arrange
            var command = new AddImportLayoutCommand()
            {
                Entity = new ImportLayout()
                {
                    Name = ""
                }
            };

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == DomainMessages.RequiredField.Format("Name").Message)), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenNameAlreadyInUse")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenNameAlreadyInUse()
        {
            // Arrange
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

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>()))
                .ReturnsAsync(new List<ImportLayout>() { new ImportLayout() { Name = command.Entity.Name } });

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == DomainMessages.AlreadyInUse.Format("Name").Message)), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenDontHaveColumnInPositionOne")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenDontHaveColumnInPositionOne()
        {
            // Arrange
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
                            Position = 2
                        }
                    }
                }
            };

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>())).ReturnsAsync(new List<ImportLayout>());

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == "There must be a column in position one.")), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenDontHaveColumnInPositionOne")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenColumnsAreNotInConsecutiveOrder()
        {
            // Arrange
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
                        },
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 3
                        }
                    }
                }
            };

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>())).ReturnsAsync(new List<ImportLayout>());

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == "Columns are not in consecutive order.")), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenDontHaveColumnInPositionOne")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenColumnNameRepeat()
        {
            // Arrange
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
                        },
                        new ImportLayoutColumn()
                        {
                            Name = "Name",
                            Position = 2
                        }
                    }
                }
            };

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>())).ReturnsAsync(new List<ImportLayout>());

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == "There are repeated columns.")), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenDontHaveColumnInPositionOne")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldPublishDomainNotification_WhenColumnNameDontExistInImportLayoutEntity()
        {
            // Arrange
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
                        },
                        new ImportLayoutColumn()
                        {
                            Name = "Date",
                            Position = 2
                        }
                    }
                }
            };
            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>()))
                .ReturnsAsync(new List<ImportLayout>());

            var propertyInfos = new List<PropertyInfo>();
            var namePropertyInfo = new Mock<PropertyInfo>();
            var nameAttribute = new ImportFieldAttribute() { Name = "Name" };
            namePropertyInfo.Setup(e => e.GetCustomAttributes(typeof(ImportFieldAttribute), false))
                .Returns(new List<object>() { nameAttribute }.ToArray());
            propertyInfos.Add(namePropertyInfo.Object);
            _mockImportFieldRetriever.Setup(e => e.GetProperties(command.Entity.ImportLayoutEntity))
                .Returns(propertyInfos.ToArray());

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == command.MessageType && s.Value == "Column name 'Date' not found in entity 'Xpto'.")), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddImportLayoutCommand_ShouldAddAndCommit_WhenValid")]
        [Trait("CommandHandler", "ImportLayout")]
        public async Task Handle_AddImportLayoutCommand_ShouldAddAndCommit_WhenValid()
        {
            // Arrange
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

            _mockImportLayoutRepository.Setup(e => e.Search(It.IsAny<Expression<Func<ImportLayout, bool>>>())).ReturnsAsync(new List<ImportLayout>());

            var propertyInfos = new List<PropertyInfo>();
            var namePropertyInfo = new Mock<PropertyInfo>();
            var nameAttribute = new ImportFieldAttribute() { Name = "Name" };
            namePropertyInfo.Setup(e => e.GetCustomAttributes(typeof(ImportFieldAttribute), false))
                .Returns(new List<object>() { nameAttribute }.ToArray());
            propertyInfos.Add(namePropertyInfo.Object);
            _mockImportFieldRetriever.Setup(e => e.GetProperties(command.Entity.ImportLayoutEntity))
                .Returns(propertyInfos.ToArray());

            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);
            _mockImportLayoutRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _importLayoutCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockImportLayoutRepository.Verify(e => e.Add(It.Is<ImportLayout>(s => s.Equals(command.Entity))), Times.Once);
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }
    }
}
