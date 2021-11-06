using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Core.Events;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GenericImporter.Domain.Core.Tests.Mediator
{
    public class MediatorHandlerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly MediatorHandler _mediatorHandler;

        public MediatorHandlerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mediatorHandler = new MediatorHandler(_mockMediator.Object);
        }

        [Fact(DisplayName = "SendCommand_ShouldSendCommandWithMediator")]
        [Trait("Core - Mediator", "MediatorHandler")]
        public async Task SendCommand_ShouldSendCommandWithMediator()
        {
            // Arrange
            var command = new Mock<Command>(Guid.NewGuid()).Object;

            // Act
            await _mediatorHandler.SendCommand(command);

            // Assert
            _mockMediator.Verify(e => e.Send(It.Is<IRequest<Unit>>(s => s.Equals(command)), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "PublishEvent_ShouldPublishWithMediator")]
        [Trait("Core - Mediator", "MediatorHandler")]
        public async Task PublishEvent_ShouldPublishWithMediator()
        {
            // Arrange
            var @event = new Mock<Event>(Guid.NewGuid()).Object;

            // Act
            await _mediatorHandler.PublishEvent(@event);

            // Assert
            _mockMediator.Verify(e => e.Publish(It.Is<INotification>(s => s.Equals(@event)), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "PublishDomainNotification_ShouldPublishWithMediator")]
        [Trait("Core - Mediator", "MediatorHandler")]
        public async Task PublishDomainNotification_ShouldPublishWithMediator()
        {
            // Arrange
            var notification = new DomainNotification("Key", "Value");

            // Act
            await _mediatorHandler.PublishDomainNotification(notification);

            // Assert
            _mockMediator.Verify(e => e.Publish(It.Is<INotification>(s => s.Equals(notification)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
