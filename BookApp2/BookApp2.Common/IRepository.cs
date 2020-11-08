using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Data
{
    public interface IRepository<TEntity, TKey, TContext> 
                                where TEntity : class
                                where TContext : DbContext
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);
        Task<int> Add(TEntity entity);
        Task<int> Delete(TEntity entity);
        Task<int> Update(TEntity entity);
    }
}
