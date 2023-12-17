using BookStore.Entities.ErrorModel;
using BookStore.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BookStore.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation($"{nameof(GlobalExceptionHandlerMiddleware)} executing..");
            
            try
            {
                _logger.LogDebug($"Global exception calling next middleware");
                await _next(httpContext); // calling next middleware
            }

            catch(Exception ex)
            {
               _logger.LogDebug($"{nameof(GlobalExceptionHandlerMiddleware)} has been hit because of error.");

                httpContext.Response.ContentType = "application/json";
 
                httpContext.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                _logger.LogError($"Something went wrong: {ex.Message}");

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = new List<string> { ex.Message }
                }.ToString());
                
            }

        }

    }
}
