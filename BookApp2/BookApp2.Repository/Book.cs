﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp2.Repository
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public Guid CatalogueId { get; set; }
    }
}
