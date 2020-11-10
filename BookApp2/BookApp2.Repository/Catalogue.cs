using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp2.Repository
{
    public class Catalogue
    {
        public Guid CatalogueId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
