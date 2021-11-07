using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using GenericImporter.Infra.Data.Contexts;
using GenericImporter.Infra.Data.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GenericImporter.Infra.Data.Repositories
{
    public class ImportLayoutRepository : Repository<ImportLayout>, IImportLayoutRepository
    {
        public ImportLayoutRepository(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<ImportLayout> ImproveQuery(IQueryable<ImportLayout> query)
        {
            return query.Include(i => i.ImportLayoutColumns);
        }
    }
}
