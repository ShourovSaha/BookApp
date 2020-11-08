using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookApp2.Data
{
    public interface IRepository<TEntity, TKey, TContext> 
                                where TEntity : class
                                where TContext : DbContext 
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
