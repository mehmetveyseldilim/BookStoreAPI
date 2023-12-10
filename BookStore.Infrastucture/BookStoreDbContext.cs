using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Entities.Models;
using BookStore.Infrastucture.Configurations;

namespace BookStore.Infrastucture
{
    public class BookStoreDbContext : DbContext
    {
       public DbSet<Book> Books {get; set;}

       public DbSet<Genre> Genres {get; set;}

       public DbSet<Author> Authors {get; set;}

       public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
       {
        
       }

       protected override void OnModelCreating(ModelBuilder modelBuilder) 
       {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
    

            base.OnModelCreating(modelBuilder);


       }


    }
}