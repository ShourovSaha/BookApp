using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Data;

namespace BookApp.Repository
{
    public class CatalogueRepository : Repository<Catalogue, int, BookAppDbContext>, ICatalogueRepository
    {
        public CatalogueRepository(BookAppDbContext context) : base(context)
        {
        }
    }
}
