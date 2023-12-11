using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void Seed(this IApplicationBuilder applicationBuilder, IHostEnvironment environment) 
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                using(var context = scope.ServiceProvider.GetService<BookStoreDbContext>()) 
                {
                    if(context is null) 
                    {
                        Console.WriteLine($"{nameof(context)} is null. Seeding cannot be instantiated");
                        return;
                    }

                    context.Database.Migrate();

                    if(!environment.IsProduction()) 
                    {
                        context.SeedDatabase<Author>("Authors.json");
                        context.SeedDatabase<Book>("Books.json");
                        context.SeedDatabase<Genre>("Genres.json");
                    }

                    context.SaveChanges();


                }
            }
        }
    }
}