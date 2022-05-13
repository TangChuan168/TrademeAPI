using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrademeAPI.Contracts
{
    public interface IRepository<T>
    {
        T Create();
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        //IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> Single(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        Task<List<T>> GetByIdAsync(object id);
        void Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
