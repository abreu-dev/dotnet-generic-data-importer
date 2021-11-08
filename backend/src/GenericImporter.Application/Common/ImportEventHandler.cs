using GenericImporter.Domain.Common;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Events.ImportEvents;
using GenericImporter.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
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
        
        private PropertyInfo FindPropertyInfoByImportFieldAttributeName(Type entityType, string importFieldAttributeName)
        {
            foreach (var property in entityType.GetProperties())
            {
                var customAttribute = property.GetCustomAttributes(typeof(ImportFieldAttribute), false).SingleOrDefault();
                if (customAttribute != null)
                {
                    var fieldAttribute = (ImportFieldAttribute)customAttribute;
                    if (fieldAttribute.Name == importFieldAttributeName)
                    {
                        return property;
                    }
                }
            }

            return null;
        }

        private async Task CallMethod(object service, object entity)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;

            var methodToExecute = service.GetType().GetMethods(flags).SingleOrDefault(x => x.Name == "Add");
            var parameter = Convert.ChangeType(entity, entity.GetType());

            var invoke = methodToExecute.Invoke(service, new object[] { parameter });
            await (invoke as Task);
        }

        public async Task Handle(ImportAddedEvent notification, CancellationToken cancellationToken)
        {
            var import = await _importRepository.GetById(notification.AggregateId);

            var entityType = Type.GetType(import.ImportLayout.ImportLayoutEntity.GetDescription());
            var customAttribute = entityType.GetCustomAttributes(typeof(ImportClassAttribute), false).SingleOrDefault();
            var classAttribute = (ImportClassAttribute)customAttribute;
            var appService = _serviceProvider.GetRequiredService(classAttribute.ServiceToUse);

            foreach (var item in import.ImportItems)
            {
                var splited = item.ImportFileLine.Split(import.ImportLayout.Separator);
                var entity = Activator.CreateInstance(entityType);

                foreach (var column in import.ImportLayout.ImportLayoutColumns)
                {
                    var property = FindPropertyInfoByImportFieldAttributeName(entityType, column.Name);
                    property.SetValue(entity, splited[column.Position - 1]);
                }

                await CallMethod(appService, entity);

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
