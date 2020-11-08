using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;

namespace BookApp2.Repository
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            services.AddDbContext<BookAppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("dbConnStr")));
            services.AddScoped<IBookAppUnitOfWork, BookAppUnitOfWork>();
        }
    }
}
