using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.CommandHandlers;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericImporter.Domain.CommandHandlers
{
    public class XptoCommandHandler : CommandHandler,
        IRequestHandler<AddXptoCommand, Unit>
    {
        public XptoCommandHandler(IMediatorHandler mediatorHandler, 
                                  INotificationHandler<DomainNotification> notifications) 
            : base(mediatorHandler, notifications) { }

        public async Task<Unit> Handle(AddXptoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            throw new NotImplementedException();
        }
    }
}
