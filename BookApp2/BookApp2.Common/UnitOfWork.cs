using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookApp2.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Save()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
