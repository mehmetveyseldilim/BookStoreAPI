using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.Domain.Contracts;
using BookStore.Domain.Response;
using BookStore.Domain.Response.BookResponse;
using BookStore.Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;

        public BooksController(IServiceManager service)
        {
            _service = service;
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

        [HttpGet("bookdetails/{id}")]
        public async Task<ActionResult<BookResponseDTO>> GetBookById(int id) 
        {
            var book = await _service.BookService.GetBookByIdAsync(id, false); 

            return Ok(book);
        }
        

    }
}