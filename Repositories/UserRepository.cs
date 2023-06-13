using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Constats;
using PublishingHouse.Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public class UserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(DbSet<User> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task AddAsync(User entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Add(User entity)
        {
            _dbSet.Add(entity);
        }

        public bool Any(Expression<Func<User, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public async Task<IEnumerable<User>> GetAsync(
            Expression<Func<User, bool>>? filter = null, 
            Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<User> query = _dbSet;

            if(filter != null) 
            {
                await Task.Run(() => query = query.Where(filter));
            }

            foreach(var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
            {
                await Task.Run(() => query = query.Include(includeProperty));
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public User GetById(int id)
        {
            return _dbSet.Where(u => u.Id == id).Single();
        }

        public void Remove(User entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(User entity)
        {
            _dbSet.Update(entity);
        }

        public IEnumerable<User> GetAllAsync()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbSet.ToList();
        }

        public User GetByLogin(string login)
        {
            return _dbSet.Where(u => u.Login == login).Single();
        }

        public User GetByLoginWithOrders(string login)
        {
            return _dbSet.Where(u => u.Login == login).Include(u => u.Orders).Single();
        }

        public List<User> GetReaders()
        {
            return _dbSet.Where(u => u.Role == UserRole.Reader.ToString()).ToList();
        }
    }
}
