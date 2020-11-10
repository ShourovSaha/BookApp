using BookApp2.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp2.Repository
{
    public interface IBookRepository : IRepository<Book, int, BookAppDbContext>
    {
        Task<IEnumerable<Book>> GetBookByGener(string gener);

        Task<(int totalRows, IEnumerable<Book> books)> GetDataDinamicaly(int numberOfRowsToShow, int pageIndex);
    }
}
