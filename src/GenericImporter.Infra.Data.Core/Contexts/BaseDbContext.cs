using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GenericImporter.Infra.Data.Core.Contexts
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
