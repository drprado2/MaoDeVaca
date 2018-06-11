using MaoDeVaca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);

        void Remove(Guid id);

        void Remove(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        Task<TEntity> GetAsync(Guid id);

        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> query = null,
            Expression<Func<TEntity, object>> order = null,
            IList<string> includeEntitities = null);

        IQueryable<TEntity> GetQuery();
    }
}
