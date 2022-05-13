using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TrademeAPI.Contracts;
using TrademeAPI.Model;

namespace TrademeAPI.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly Dbcontext _dbContext;
        private readonly DbSet<T> _DbSet;


        public Repository(Dbcontext dbcontext)
        {
            _dbContext = dbcontext;
            _DbSet = _dbContext.Set<T>();
        }

        public T Create()
        {
            var entity = new T();
            return entity;
        }

        public Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsQueryable().Where(predicate).ToListAsync();
        }

        public Task<T> Single(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public Task<List<T>> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _DbSet.Add(entity);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _DbSet.Update(entity);

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _DbSet.Remove(entity);

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }



        IQueryable<T> IRepository<T>.GetQueryable()
        {
            IQueryable<T> query = _DbSet.AsQueryable();
            return query;
        }



        Task<bool> IRepository<T>.Any(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsQueryable().AnyAsync(predicate);
              
        }
    }
}
