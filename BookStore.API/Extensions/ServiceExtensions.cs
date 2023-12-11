using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("Postgres")!;

            if(string.IsNullOrEmpty(connectionString)) 
            {
                Console.WriteLine("Connection string is null or empty");
                return;
            }

            services.AddDbContext<BookStoreDbContext>(options => 
            {
                options.UseNpgsql(connectionString, 
                b => b.MigrationsAssembly("BookStore.API")
                .MigrationsHistoryTable("__EFMigrationsHistory", schema: BookStoreDbContext.SCHEMA_NAME));

            });
        }
    }
}