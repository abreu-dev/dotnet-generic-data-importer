using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using GenericImporter.Infra.Data.Contexts;
using GenericImporter.Infra.Data.Core.Repositories;

namespace GenericImporter.Infra.Data.Repositories
{
    public class ImportLayoutRepository : Repository<ImportLayout>, IImportLayoutRepository
    {
        public ImportLayoutRepository(DataContext dataContext) : base(dataContext) { }
    }
}
