using Microsoft.EntityFrameworkCore;
using PublishingHouse.Models.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public class OrderRepository
    {
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(DbSet<Order> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(Order entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(Order entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public bool Any(Expression<Func<Order, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<Order>> GetAsync(
            Expression<Func<Order, bool>>? filter = null, 
            Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<Order> query = _dbSet;

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

        public Order GetById(int id)
        {
            return _dbSet.Where(o => o.Id == id).Single();
        }

        public void Remove(Order entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(Order entity)
        {
            _dbSet.Update(entity);
        }

        public List<Order> GetByUserId(int userId)
        {
            return _dbSet.Where(o => o.UserId == userId).Include(o => o.PrintedEditions).ToList();
        }
    }
}
