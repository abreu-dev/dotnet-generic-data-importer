using GenericImporter.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericImporter.Infra.Data.Core.Contexts
{
    public interface IDbContext : IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
    }
}
