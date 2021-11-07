using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using GenericImporter.Infra.Data.Contexts;
using GenericImporter.Infra.Data.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GenericImporter.Infra.Data.Repositories
{
    public class ImportRepository : Repository<Import>, IImportRepository
    {
        public ImportRepository(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<Import> ImproveQuery(IQueryable<Import> query)
        {
            return query.Include(i => i.ImportLayout)
                .ThenInclude(i => i.ImportLayoutColumns)
                .Include(i => i.ImportItems);
        }
    }
}
