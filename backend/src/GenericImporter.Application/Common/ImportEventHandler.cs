using GenericImporter.Application.DataTransferObjects.XptoDtos;
using GenericImporter.Application.Interfaces;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Events.ImportEvents;
using GenericImporter.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly DomainNotificationHandler _notifications;

        public ImportEventHandler(IMediatorHandler mediatorHandler,
                                  IImportRepository importRepository, 
                                  IServiceProvider serviceProvider,
                                  INotificationHandler<DomainNotification> notifications)
        {
            _mediatorHandler = mediatorHandler;
            _importRepository = importRepository;
            _serviceProvider = serviceProvider;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task Handle(ImportAddedEvent notification, CancellationToken cancellationToken)
        {
            var import = await _importRepository.GetById(notification.AggregateId);

            var appService = _serviceProvider.GetRequiredService<IXptoAppService>();

            foreach (var item in import.ImportItems)
            {
                var addDto = new AddXptoDto()
                {
                    Name = item.ImportFileLine
                };
                await appService.Add(addDto);

                if (_notifications.HasNotifications())
                {
                    item.Error = string.Join(", ", _notifications.GetNotifications().Select(c => c.Value));
                }

                item.Processed = true;

                _notifications.ClearNotifications();
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
