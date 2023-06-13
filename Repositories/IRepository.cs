using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(int  id);
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = ""
            );
        bool Any(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
    }
}
