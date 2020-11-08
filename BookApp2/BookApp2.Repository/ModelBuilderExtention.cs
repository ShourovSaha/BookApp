﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp2.Repository
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Catalogue>().HasMany(b => b.Books).WithOne();

            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C# Learing", Author = "Joe", Publisher = "Aprex", Genre = "Programmoig", Price = 200, CatalogueId = 1 },
                new Book { Id = 2, Title = "PL/SQL Learing", Author = "Alex", Publisher = "Oracle Publication", Genre = "Database", Price = 220, CatalogueId = 1 }
                );

            builder.Entity<Catalogue>().HasData(
                new Catalogue
                {
                    CatalogueId = 1,
                    Name = "CSE"
                });
        }
    }
}
