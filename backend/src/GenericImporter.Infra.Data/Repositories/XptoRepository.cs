using GenericImporter.Domain.Entities;
using GenericImporter.Domain.Interfaces;
using GenericImporter.Infra.Data.Contexts;
using Core.Infra.Data.Repositories;

namespace GenericImporter.Infra.Data.Repositories
{
    public class XptoRepository : Repository<Xpto>, IXptoRepository
    {
        public XptoRepository(DataContext dataContext) : base(dataContext) { }
    }
}
