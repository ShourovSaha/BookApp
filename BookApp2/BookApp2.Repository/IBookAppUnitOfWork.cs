using System;
using System.Collections.Generic;
using System.Text;
using BookApp2.Common;

namespace BookApp2.Repository
{
    public interface IBookAppUnitOfWork : IUnitOfWork
    {
        IBookRepository BookRepository { get; set; }
        ICatalogueRepository CatalogueRepository { get; set; }
    }
}
