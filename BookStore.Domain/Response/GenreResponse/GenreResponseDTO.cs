using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.GenreResponse
{
    public class GenreResponseDTO
    {
        public int Id {get; set;}

        public required string Name {get; set;}

        public ICollection<GenreBookResponseDTO>? Books {get; set;}
    }
}