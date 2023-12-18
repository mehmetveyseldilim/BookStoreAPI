using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.AuthorResponse
{
    public class AuthorGenreResponseDTO
    {
        public int Id {get; set;}
        public required string Name {get; set;}
    }
}