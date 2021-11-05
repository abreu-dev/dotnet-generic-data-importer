using System.Threading.Tasks;

namespace GenericImporter.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
