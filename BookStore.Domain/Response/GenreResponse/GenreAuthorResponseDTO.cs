using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.GenreResponse
{
    public class GenreAuthorResponseDTO
    {
        public int Id {get; set;}

        public required string Name { get; set; }

        public required string Surname {get; set;}

        public DateOnly Birth {get; set;}

    }
}