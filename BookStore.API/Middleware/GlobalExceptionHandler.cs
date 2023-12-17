using BookStore.Entities.ErrorModel;
using BookStore.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BookStore.API.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");

            try 
            {
                _logger.LogDebug($"{nameof(GlobalExceptionHandler)} has been hit. Calling next middleware");
                await _next(httpContext); // calling next middleware
            }
            catch(Exception)
            {
                _logger.LogDebug($"{nameof(GlobalExceptionHandler)} has been hit because of error.");
                
                httpContext.Response.ContentType = "application/json";
                var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null && contextFeature.Error != null)
                {
                    httpContext.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    _logger.LogError($"Something went wrong: {contextFeature.Error}");

                    await httpContext.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = httpContext.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                    }.ToString());
                }
            }

        }

    }
}
