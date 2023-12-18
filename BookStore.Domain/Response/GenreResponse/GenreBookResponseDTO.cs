using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.GenreResponse
{
    public class GenreBookResponseDTO
    {
        public int Id {get; set;}

        public required string Title { get; set; }

        public DateOnly ReleaseDate {get; set;}

        //* Navigation Properties

        public GenreAuthorResponseDTO? Author {get; set;}

    }
}