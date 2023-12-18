using BookStore.Entities.ErrorModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filters
{
    public class HandleValidationFailureFilterAttribute : IAsyncActionFilter
    {
        private readonly ILogger<HandleValidationFailureFilterAttribute> _logger;

        public HandleValidationFailureFilterAttribute(ILogger<HandleValidationFailureFilterAttribute> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.

            var resultContext = await next(); // Move to the next stage in the pipeline.

            if(resultContext.Result is BadRequestObjectResult badRequestResult && 
            badRequestResult.Value is ValidationResult validationResult )
            {
                
                var errorDetails = CreateErrorDetails(validationResult);

                resultContext.Result = new BadRequestObjectResult(errorDetails);


                _logger.LogError("Validation Errors => {@errorDetails}", errorDetails.Message);
                
                
            }

            // Do something after the action executes.
        }


        private ErrorDetails CreateErrorDetails(ValidationResult validationResult)
        {
            var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            return new ErrorDetails()
            {
                StatusCode = 400,
                Message = errorMessages
            };
        }

    }
}

