using Microsoft.EntityFrameworkCore;
using PublishingHouse.Models.PrintedEditionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public class PrintedEditionRepository
    {
        private readonly DbSet<PrintedEdition> _dbSet;

        public PrintedEditionRepository(DbSet<PrintedEdition> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(PrintedEdition entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(PrintedEdition entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public bool Any(Expression<Func<PrintedEdition, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IEnumerable<PrintedEdition> GetAll()
        {
            _dbSet.Load();

            return _dbSet.ToList();
        }

        public async Task<IEnumerable<PrintedEdition>> GetAsync(
            Expression<Func<PrintedEdition, bool>>? filter = null, 
            Func<IQueryable<PrintedEdition>, IOrderedQueryable<PrintedEdition>>? orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<PrintedEdition> query = _dbSet;

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

        public PrintedEdition GetById(int id)
        {
            return _dbSet.Where(p => p.Id == id).Single();
        }

        public void Remove(PrintedEdition entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
