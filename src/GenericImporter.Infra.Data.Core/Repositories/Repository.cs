using GenericImporter.Domain.Core.Entities;
using GenericImporter.Domain.Core.Interfaces;
using GenericImporter.Infra.Data.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericImporter.Infra.Data.Core.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly BaseDbContext _baseDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
            _dbSet = baseDbContext.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _baseDbContext;

        public virtual IQueryable<TEntity> Query()
        {
            return _dbSet;
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
