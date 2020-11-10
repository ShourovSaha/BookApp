using System.Linq;
using BookApp2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApp2.Repository
{
    public class BookRepository : Repository<Book, int, BookAppDbContext>, IBookRepository
    {
        public BookRepository(BookAppDbContext context) : base(context)
        { }


        public async Task<IEnumerable<Book>> GetBookByGener(string gener)
        {
            return await _context.Books.AsQueryable().Where(g => g.Genre == gener).ToListAsync();
        }

        public async Task<(int totalRows, IEnumerable<Book> books)> GetDataDinamicaly(int numberOfRowsToShow, int pageIndex)
        {
            var data =  await _context.Books.Skip<Book>(numberOfRowsToShow * (pageIndex - 1)).Take<Book>(numberOfRowsToShow).ToListAsync();
            var totalRows = await this.Count(c => c.Id > -1);
            return (totalRows, data);
        }
    }
}
