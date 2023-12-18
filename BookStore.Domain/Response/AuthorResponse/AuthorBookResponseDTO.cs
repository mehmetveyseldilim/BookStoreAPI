using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.AuthorResponse
{
    public class AuthorBookResponseDTO
    {
        public int Id {get; set;}
        public required string Title { get; set; }

        public DateOnly ReleaseDate {get; set;}

        public AuthorGenreResponseDTO? AuthorGenreResponseDTO {get; set;}
    }
}