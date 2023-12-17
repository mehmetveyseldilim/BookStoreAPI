using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Contracts;
using BookStore.Domain.Services;
using BookStore.Infrastucture;
using BookStore.Infrastucture.Contracts;
using BookStore.Infrastucture.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookStore.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("Postgres")!;

            if(string.IsNullOrWhiteSpace(connectionString)) 
            {
                Console.WriteLine("Connection string is null or empty. Returning withoud adding db context");
                return services;
            }

            services.AddDbContext<BookStoreDbContext>(options => 
            {
                options.UseNpgsql(connectionString, 
                b => b.MigrationsAssembly("BookStore.API")
                .MigrationsHistoryTable("__EFMigrationsHistory", schema: BookStoreDbContext.SCHEMA_NAME));

            });

            return services;
        }

        public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }

        public static IServiceCollection ConfigureServiceManager(this IServiceCollection services)  
        {
	        services.AddScoped<IServiceManager, ServiceManager>();

            return services;

        }

        public static IServiceCollection AddAutoMapperService(this IServiceCollection services) 
        {
            // services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

            return services;

        }

    }
}