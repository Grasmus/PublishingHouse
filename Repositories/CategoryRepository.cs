using Microsoft.EntityFrameworkCore;
using PublishingHouse.Models.CategoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public class CategoryRepository
    {
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(DbSet<Category> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(Category entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(Category entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public bool Any(Expression<Func<Category, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<Category>> GetAsync(
            Expression<Func<Category, bool>>? filter = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<Category> query = _dbSet;

            if (filter != null)
            {
                await Task.Run(() => query = query.Where(filter));
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                await Task.Run(() => query = query.Include(includeProperty));
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public Category GetById(int id)
        {
            return _dbSet.Where(o => o.Id == id).Single();
        }

        public void Remove(Category entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(Category entity)
        {
            _dbSet.Update(entity);
        }
    }
}
