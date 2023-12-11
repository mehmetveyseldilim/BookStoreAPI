using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Contracts;
using BookStore.Domain.Services;
using BookStore.Infrastucture;
using BookStore.Infrastucture.Contracts;
using BookStore.Infrastucture.Repository;
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

        public static void ConfigureRepositoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)  
        {
	        services.AddScoped<IServiceManager, ServiceManager>();

        }

        public static void AddAutoMapperService(this IServiceCollection services) 
        {
            // services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}