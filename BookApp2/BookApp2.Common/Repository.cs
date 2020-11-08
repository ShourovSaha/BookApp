using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookApp2.Data
{
    public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext> where TEntity : class
                                                                                            where TContext : DbContext, IDisposable
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
            => await _context.Set<TEntity>().AsQueryable().ToListAsync();


        public async Task<TEntity> GetById(TKey id)
            => await _context.Set<TEntity>().FindAsync(id);


        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> filter = null)
        {
            int count = 0;
            if (filter != null)
            {
                count = await _dbSet.AsQueryable().Where(filter).CountAsync();
            }
            return count;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
    }
}
