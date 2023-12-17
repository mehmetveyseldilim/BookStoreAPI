using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Middleware;

namespace BookStore.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder applicationBuilder)
        {   
            applicationBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            return applicationBuilder;
        }
    }
}
