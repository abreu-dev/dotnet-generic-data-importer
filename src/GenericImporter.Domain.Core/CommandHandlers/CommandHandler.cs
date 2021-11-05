using GenericImporter.Domain.Core.Common;
using GenericImporter.Domain.Core.Exceptions;
using GenericImporter.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace GenericImporter.Domain.Core.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected async Task<bool> Commit(IUnitOfWork uow)
        {
            if (!await uow.Commit())
            {
                throw new DomainException(DomainMessages.CommitFailed.Message);
            }

            return true;
        }
    }
}
