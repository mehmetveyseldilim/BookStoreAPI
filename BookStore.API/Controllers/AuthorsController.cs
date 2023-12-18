using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.Domain.Contracts;
using BookStore.Domain.Response.AuthorResponse;
using BookStore.Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _service;

        private readonly ILogger<AuthorsController> _logger;


        public AuthorsController(IServiceManager service, ILogger<AuthorsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<AuthorResponseDTO>>> GetAllAuthors([FromQuery] AuthorRequestParameters parameters) 
        {
            var authors = await _service.AuthorService.GetAllAuthorsAsync(parameters, false); 

            var pagedAuthors = PagedList<AuthorResponseDTO>
                            .ToPagedList(
                                authors, 
                                parameters.PageNumber,
                                parameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedAuthors.MetaData));
            
            return Ok(pagedAuthors);
        }




    }
}