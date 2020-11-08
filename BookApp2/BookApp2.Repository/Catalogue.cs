using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Repository
{
    public class Catalogue
    {
        public int CatalogueId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
