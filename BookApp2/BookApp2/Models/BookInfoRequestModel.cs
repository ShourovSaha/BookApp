using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp2.Repository;

namespace BookApp2.Models
{
    public class BookInfoRequestModel
    {
        public string CatalogueName { get; set; }
        public List<BookInfoList> BooksInfo; 
    }

    public class BookInfoList
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}
