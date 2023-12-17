using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Middleware;

namespace BookStore.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureGlobalExceptionHandler(this IApplicationBuilder applicationBuilder)
        {   
            applicationBuilder.UseMiddleware<GlobalExceptionHandler>();

            return applicationBuilder;
        }
    }
}



