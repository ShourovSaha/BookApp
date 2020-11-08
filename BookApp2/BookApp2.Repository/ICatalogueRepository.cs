using BookApp2.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp2.Repository
{
    public interface ICatalogueRepository : IRepository<Catalogue, int, BookAppDbContext>
    {
    }
}
