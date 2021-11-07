using GenericImporter.Domain.Commands.ImportLayoutCommands;
using GenericImporter.Domain.Core.CommandHandlers;
using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Enums;
using GenericImporter.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
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

            if (!await ValidateIfColumsAreValid(request.MessageType, request.Entity.ImportLayoutEntity, request.Entity.ImportLayoutColumns))
            {
                return Unit.Value;
            }

            _importLayoutRepository.Add(request.Entity);

            await Commit(_importLayoutRepository.UnitOfWork);

            return Unit.Value;
        }

        private async Task<bool> ValidateIfColumsAreValid(string messageType, 
                                                          ImportLayoutEntity importLayoutEntity, 
                                                          IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            if (!await ValidateIfColumnsPositionAreValid(messageType, importLayoutColumns))
            {
                return false;
            }

            if (!await ValidateIfColumnNameRepeat(messageType, importLayoutColumns))
            {
                return false;
            }

            if (!await ValidateIfColumnNameExists(messageType, importLayoutEntity, importLayoutColumns))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnsPositionAreValid(string messageType, 
                                                                   IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            var positions = importLayoutColumns.Select(x => x.Position);

            if (!positions.Any(x => x == 1))
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "There must be a column in position one."));
                return false;
            }

            var isConsecutive = !positions.Select((i, j) => i - j).Distinct().Skip(1).Any();
            if (!isConsecutive)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "Columns are not in consecutive order."));
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnNameRepeat(string messageType,
                                                            IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            if (importLayoutColumns.Count() != importLayoutColumns.GroupBy(x => x.Name).Count())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "There are repeated columns."));
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnNameExists(string messageType,
                                                            ImportLayoutEntity importLayoutEntity,
                                                            IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            var entityType = Type.GetType($"GenericImporter.Domain.Entities.{importLayoutEntity}");

            foreach (var column in importLayoutColumns)
            {
                var property = entityType.GetProperty(column.Name);
                if (property == null)
                {
                    await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                        $"Column name '{column.Name}' not found in entity '{importLayoutEntity}'."));
                    return false;
                }
            }

            return true;
        }
    }
}
