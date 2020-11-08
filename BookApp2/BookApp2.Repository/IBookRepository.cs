using BookApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository
{
    public interface IBookRepository : IRepository<Book, int, BookAppDbContext>
    {
        Task<IEnumerable<Book>> GetBookByGener(string gener);
    }
}
