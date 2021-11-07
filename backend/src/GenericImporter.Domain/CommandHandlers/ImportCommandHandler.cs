using GenericImporter.Domain.Commands.ImportCommands;
using GenericImporter.Domain.Core.CommandHandlers;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenericImporter.Domain.CommandHandlers
{
    public class ImportCommandHandler : CommandHandler,
        IRequestHandler<AddImportCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IImportLayoutRepository _importLayoutRepository;
        private readonly IImportRepository _importRepository;

        public ImportCommandHandler(IMediatorHandler mediatorHandler,
                                    INotificationHandler<DomainNotification> notifications,
                                    IImportLayoutRepository importLayoutRepository,
                                    IImportRepository importRepository)
            : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _importLayoutRepository = importLayoutRepository;
            _importRepository = importRepository;
        }

        public async Task<Unit> Handle(AddImportCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            if (!(await _importLayoutRepository.Search(x => x.Id == request.Entity.ImportLayoutId)).Any())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(request.MessageType,
                    DomainMessages.NotFound.Format("ImportLayout").Message));
                return Unit.Value;
            }

            request.Entity.Date = DateTime.UtcNow;
            request.Entity.ItemsUnprocessed = request.Entity.ImportItems.Count();
            _importRepository.Add(request.Entity);

            await Commit(_importRepository.UnitOfWork);

            return Unit.Value;
        }
    }
}
