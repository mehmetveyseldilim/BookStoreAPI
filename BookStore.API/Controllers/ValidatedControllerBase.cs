// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using FluentValidation;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

// namespace BookStore.API.Controllers
// {
//     public abstract class ValidatedControllerBase<CreateDTO, UpdateDTO> : ControllerBase
//     {
//         protected readonly ILogger<ValidatedControllerBase> _logger;


//         protected ValidatedControllerBase(ILogger<ValidatedControllerBase> logger)
//         {
//             _logger = logger;
//         }

//         protected IActionResult HandleValidationFailure(TDTO dto, IValidator<T> validator, string actionName) 
//         {
//             var validationResult = _validator.Validate(dto);

//             return BadRequest(validationResult);
//         }
        
        

//     }
// }