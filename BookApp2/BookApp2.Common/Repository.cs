using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext> where TEntity : class
                                                                                            where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsQueryable().ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? 1 : 0;
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

        public async Task<int> Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? 1 : 0;
        }

        public Task<int> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
