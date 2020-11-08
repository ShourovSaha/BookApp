using System;
using System.Collections.Generic;
using System.Text;
using BookApp2.Common;

namespace BookApp2.Repository
{
    public class BookAppUnitOfWork : UnitOfWork, IBookAppUnitOfWork
    {
        readonly BookAppDbContext _context;

        public IBookRepository BookRepository { get; set; }

        public ICatalogueRepository CatalogueRepository { get; set; }


        public BookAppUnitOfWork(BookAppDbContext context, IBookRepository bookRepository, ICatalogueRepository catalogueRepository): base(context)
        {
            _context = context;
            BookRepository = bookRepository;
            CatalogueRepository = catalogueRepository;
        }
    }
}
