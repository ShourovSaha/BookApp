using System;
using System.Collections.Generic;
using System.Text;
using BookApp2.Data;

namespace BookApp2.Repository
{
    public class CatalogueRepository : Repository<Catalogue, int, BookAppDbContext>, ICatalogueRepository
    {
        public CatalogueRepository(BookAppDbContext context) : base(context)
        {
        }
    }
}
