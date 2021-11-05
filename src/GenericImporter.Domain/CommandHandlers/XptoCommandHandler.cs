using GenericImporter.Domain.Commands.XptoCommands;
using GenericImporter.Domain.Core.CommandHandlers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericImporter.Domain.CommandHandlers
{
    public class XptoCommandHandler : CommandHandler,
        IRequestHandler<AddXptoCommand, Unit>
    {
        public async Task<Unit> Handle(AddXptoCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
