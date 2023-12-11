using BookStore.Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedDatabase<T>(this DbContext context, string filePath) where T : class
        {
            if(!context.Set<T>().Any()) 
            {
                var objects = SeedHelper.SeedData<T>(filePath);
                context.Set<T>().AddRange(objects);
            }
        }
    }
}