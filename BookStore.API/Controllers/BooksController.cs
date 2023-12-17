using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.API.Filters;
using BookStore.API.Validators;
using BookStore.API.Validators.BookValidators;
using BookStore.Domain.Contracts;
using BookStore.Domain.Request;
using BookStore.Domain.Response;
using BookStore.Domain.Response.BookResponse;
using BookStore.Entities.ErrorModel;
using BookStore.Entities.RequestFeatures;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IValidator<BookCreateDTO> _createBookValidator;
        private readonly IValidator<BookUpdateDTO> _updateBookValidator;

        private readonly ILogger<BooksController> _logger;

        public BooksController(
        IServiceManager service,
        IValidator<BookCreateDTO> createBookValidator,
        IValidator<BookUpdateDTO> updateBookValidator,
        ILogger<BooksController> logger) 
        {
            _service = service;
            _createBookValidator = createBookValidator;
            _updateBookValidator = updateBookValidator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<BookResponseDTO>>> GetAllBooks([FromQuery] BookRequestParameters bookRequestParameters) 
        {
            var books = await _service.BookService.GetAllBooksAsync(bookRequestParameters, false); 

            var pagedBooks = PagedList<BookResponseDTO>
                            .ToPagedList(
                                books, 
                                bookRequestParameters.PageNumber,
                                bookRequestParameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedBooks.MetaData));
            return Ok(pagedBooks);
        }

        [HttpGet("bookdetails/{id}", Name = nameof(GetBookById))]
        public async Task<ActionResult<BookResponseDTO>> GetBookById(int id) 
        {
            var book = await _service.BookService.GetBookByIdAsync(id, false); 

            return Ok(book);
        }


        [HttpPost]
        [ServiceFilter(typeof(HandleValidationFailureFilterAttribute))]
        public  async Task<ActionResult<BookResponseDTO>> CreateBook(BookCreateDTO createBookDTO) 
        {
            var validationResult = _createBookValidator.Validate(createBookDTO);
            if(!validationResult.IsValid) 
            {
                _logger.LogError($"Validation Errors Happened In {nameof(CreateBook)}.");
                // return HandleValidationFailure(validationResult);
                return BadRequest(validationResult);
            }

            var result = await _service.BookService.CreateBookAsync(createBookDTO);

            return CreatedAtRoute(nameof(GetBookById), new {id = result.Id}, result);
        }

        [HttpPut]
        [ServiceFilter(typeof(HandleValidationFailureFilterAttribute))]
        public IActionResult UpdateBook(BookUpdateDTO bookUpdateDTO) 
        {
            var validationResult = _updateBookValidator.Validate(bookUpdateDTO);

            if(!validationResult.IsValid) 
            {
                _logger.LogError($"Validation Errors Happened In {nameof(UpdateBook)}.");
                return BadRequest();
                // return HandleValidationFailure(validationResult);
            }

            return Ok();
        }



    }
}