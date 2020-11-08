using System.Linq;
using BookApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApp.Repository
{
    public class BookRepository : Repository<Book, int, BookAppDbContext>, IBookRepository
    {
        public BookRepository(BookAppDbContext context) : base(context)
        { }


        public async Task<IEnumerable<Book>> GetBookByGener(string gener)
        {
            return await _context.Books.AsQueryable().Where(g => g.Genre == gener).ToListAsync();
        }
    }
}
