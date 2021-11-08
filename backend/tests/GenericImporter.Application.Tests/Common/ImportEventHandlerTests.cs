using AutoMapper;
using GenericImporter.Application.Common;
using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Application.Interfaces;
using GenericImporter.Application.Services;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Interfaces;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using GenericImporter.Domain.Events.ImportEvents;
using GenericImporter.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Application.Tests.Common
{
    public class ImportEventHandlerTests
    {
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly Mock<IImportRepository> _mockImportRepository;
        private readonly Mock<IServiceProvider> _mockServiceProvider;
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ImportEventHandler _importEventHandler;

        public ImportEventHandlerTests()
        {
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockImportRepository = new Mock<IImportRepository>();
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _importEventHandler = new ImportEventHandler(
                _mockMediatorHandler.Object,
                _mockImportRepository.Object,
                _mockServiceProvider.Object,
                _mockNotifications.Object);
        }

        [Fact(DisplayName = "Handle_ImportAddedEvent_ShouldProcessItemSuccessfully_WhenImportLayoutEntityIsXpto")]
        [Trait("Common", "ImportEventHandler")]
        public async Task Handle_ImportAddedEvent_ShouldProcessItemSuccessfully_WhenImportLayoutEntityIsXpto()
        {
            // Arrange
            var message = new ImportAddedEvent(Guid.NewGuid());
            var entity = new Import()
            {
                ImportLayoutId = message.AggregateId,
                Date = DateTime.UtcNow,
                ImportItems = new List<ImportItem>()
                {
                    new ImportItem()
                    {
                        ImportFileLine = "XptoEntityOne"
                    }
                },
                ImportLayout = new ImportLayout()
                {
                    Name = "Xpto",
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

            _mockImportRepository.Setup(e => e.GetById(message.AggregateId)).ReturnsAsync(entity);
            var mockXptoAppService = new Mock<XptoAppService>(_mockMapper.Object, _mockMediatorHandler.Object,
                new Mock<IXptoRepository>().Object);
            _mockServiceProvider.Setup(e => e.GetService(typeof(IXptoAppService)))
                .Returns(mockXptoAppService.Object);
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);
            _mockImportRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _importEventHandler.Handle(message, new CancellationToken());

            // Assert
            mockXptoAppService.Verify(e => e.Add(It.Is<AddXptoDto>(x => x.Name == "XptoEntityOne")), Times.Once);
            Assert.Equal(1, entity.ItemsSuccessfullyProcessed);
            Assert.Equal(0, entity.ItemsFailedProcessed);
            Assert.Equal(0, entity.ItemsUnprocessed);
            Assert.True(entity.Processed);
            Assert.True(entity.ImportItems.Single().Processed);
            Assert.Null(entity.ImportItems.Single().Error);
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }

        [Fact(DisplayName = "Handle_ImportAddedEvent_ShouldFailedProcessItem_WhenImportLayoutEntityIsXpto")]
        [Trait("Common", "ImportEventHandler")]
        public async Task Handle_ImportAddedEvent_ShouldFailedProcessItem_WhenImportLayoutEntityIsXpto()
        {
            // Arrange
            var message = new ImportAddedEvent(Guid.NewGuid());
            var entity = new Import()
            {
                ImportLayoutId = message.AggregateId,
                Date = DateTime.UtcNow,
                ImportItems = new List<ImportItem>()
                {
                    new ImportItem()
                    {
                        ImportFileLine = "XptoEntityOne"
                    }
                },
                ImportLayout = new ImportLayout()
                {
                    Name = "Xpto",
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
            
            _mockImportRepository.Setup(e => e.GetById(message.AggregateId)).ReturnsAsync(entity);
            var mockXptoAppService = new Mock<XptoAppService>(_mockMapper.Object, _mockMediatorHandler.Object,
                new Mock<IXptoRepository>().Object);
            _mockServiceProvider.Setup(e => e.GetService(typeof(IXptoAppService)))
                .Returns(mockXptoAppService.Object);
            var notifications = new List<DomainNotification>()
            {
                new DomainNotification("Key", "Value1"),
                new DomainNotification("Key", "Value2"),
                new DomainNotification("Key", "Value3")
            };
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(true);
            _mockNotifications.Setup(e => e.GetNotifications()).Returns(notifications);
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);
            _mockImportRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _importEventHandler.Handle(message, new CancellationToken());

            // Assert
            mockXptoAppService.Verify(e => e.Add(It.Is<AddXptoDto>(x => x.Name == "XptoEntityOne")), Times.Once);
            Assert.Equal(0, entity.ItemsSuccessfullyProcessed);
            Assert.Equal(1, entity.ItemsFailedProcessed);
            Assert.Equal(0, entity.ItemsUnprocessed);
            Assert.True(entity.Processed);
            Assert.True(entity.ImportItems.Single().Processed);
            Assert.Equal("Value1, Value2, Value3", entity.ImportItems.Single().Error);
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }

        [Fact(DisplayName = "Handle_ImportAddedEvent_ShouldPublishDomainNotification_WhenImportLayoutEntityIsXpto")]
        [Trait("Common", "ImportEventHandler")]
        public async Task Handle_ImportAddedEvent_ShouldPublishDomainNotification_WhenImportLayoutEntityIsXpto()
        {
            // Arrange
            var message = new ImportAddedEvent(Guid.NewGuid());
            var entity = new Import()
            {
                ImportLayoutId = message.AggregateId,
                Date = DateTime.UtcNow,
                ImportItems = new List<ImportItem>()
                {
                    new ImportItem()
                    {
                        ImportFileLine = "XptoEntityOne"
                    }
                },
                ImportLayout = new ImportLayout()
                {
                    Name = "Xpto",
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

            _mockImportRepository.Setup(e => e.GetById(message.AggregateId)).ReturnsAsync(entity);
            var mockXptoAppService = new Mock<XptoAppService>(_mockMapper.Object, _mockMediatorHandler.Object,
                new Mock<IXptoRepository>().Object);
            _mockServiceProvider.Setup(e => e.GetService(typeof(IXptoAppService)))
                .Returns(mockXptoAppService.Object);
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(false);
            _mockImportRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _importEventHandler.Handle(message, new CancellationToken());

            // Assert
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(
                It.Is<DomainNotification>(x => x.Key == "Commit" && x.Value == DomainMessages.CommitFailed.Message)), 
                Times.Once);
        }
    }
}
