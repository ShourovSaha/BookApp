using Microsoft.EntityFrameworkCore;


namespace BookApp.Repository
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
