using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp2.Models
{
    public class BookInfoRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public int CatalogueId { get; set; }
        public string CatalogueName { get; set; }
    }
}
