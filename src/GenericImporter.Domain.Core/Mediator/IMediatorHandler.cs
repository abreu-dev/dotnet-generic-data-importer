using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace GenericImporter.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<Unit> SendCommand<T>(T command) where T : Command;
    }
}
