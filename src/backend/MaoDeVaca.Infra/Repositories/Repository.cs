using MaoDeVaca.Domain.Entities;
using MaoDeVaca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace MaoDeVaca.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MaoDeVacaDbContext _dbContext;

        public Repository(MaoDeVacaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync<TEntity>(entity);
        }

        public void Remove(Guid id)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(id);
            Remove(entityToDelete);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entityToDelete);
            }
            _dbContext.Set<TEntity>().Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbContext.Set<TEntity>().Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> query = null,
            Expression<Func<TEntity, object>> order = null,
            IList<string> includeEntitities = null)
        {
            var entityQuery = _dbContext.Set<TEntity>().AsQueryable();

            if (query != null)
                entityQuery = entityQuery.Where(query);

            if(includeEntitities != null && includeEntitities.Any())
                foreach (var entity in includeEntitities)
                    entityQuery = entityQuery.Include(entity);

            if (order != null)
                entityQuery = entityQuery.OrderBy(order);

            return await entityQuery.ToListAsync();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
