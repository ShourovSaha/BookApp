using Microsoft.EntityFrameworkCore;


namespace BookApp2.Repository
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }
    }
}
