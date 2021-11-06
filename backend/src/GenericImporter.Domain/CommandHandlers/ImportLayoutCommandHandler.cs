using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.CommandHandlers;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenericImporter.Domain.CommandHandlers
{
    public class ImportLayoutCommandHandler : CommandHandler,
        IRequestHandler<AddImportLayoutCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IImportLayoutRepository _importLayoutRepository;

        public ImportLayoutCommandHandler(IMediatorHandler mediatorHandler,
                                          INotificationHandler<DomainNotification> notifications,
                                          IImportLayoutRepository importLayoutRepository)
            : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _importLayoutRepository = importLayoutRepository;
        }

        public async Task<Unit> Handle(AddImportLayoutCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            if ((await _importLayoutRepository.Search(x => x.Name == request.Entity.Name)).Any())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(request.MessageType,
                    DomainMessages.AlreadyInUse.Format("Name").Message));
                return Unit.Value;
            }

            _importLayoutRepository.Add(request.Entity);

            await Commit(_importLayoutRepository.UnitOfWork);

            return Unit.Value;
        }
    }
}
