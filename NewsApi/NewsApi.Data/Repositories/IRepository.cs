using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.Repositories
{
    public interface IRepository<T>
    {
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAsync(Expression<Func<T, bool>> expression);
    }
}
