using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Events.ImportEvents;
using GenericImporter.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenericImporter.Application.Common
{
    public class ImportEventHandler :
        INotificationHandler<ImportAddedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IImportRepository _importRepository;

        public ImportEventHandler(IMediatorHandler mediatorHandler, 
                                  IImportRepository importRepository)
        {
            _mediatorHandler = mediatorHandler;
            _importRepository = importRepository;
        }

        public async Task Handle(ImportAddedEvent notification, CancellationToken cancellationToken)
        {
            var import = await _importRepository.GetById(notification.AggregateId);

            foreach (var item in import.ImportItems)
            {
                if (item.ImportFileLine == "ImportedXPTO1")
                {
                    item.Processed = true;
                    item.Error = "Falhou.";
                }
                else if (item.ImportFileLine == "ImportedXPTO2")
                {
                    item.Processed = true;
                }
                else
                {
                    item.Processed = false;
                }
            }

            import.ItemsSuccessfullyProcessed = import.ImportItems.Count(x => x.Processed && string.IsNullOrEmpty(x.Error));
            import.ItemsFailedProcessed = import.ImportItems.Count(x => x.Processed && !string.IsNullOrEmpty(x.Error));
            import.ItemsUnprocessed = import.ImportItems.Count(x => !x.Processed);
            import.Processed = import.ItemsUnprocessed == 0;

            if (!await _importRepository.UnitOfWork.Commit())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("Commit",
                    DomainMessages.CommitFailed.Message));
            }
        }
    }
}
