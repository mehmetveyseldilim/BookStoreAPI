using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Response.AuthorResponse
{
    public class AuthorResponseDTO
    {
        public int Id {get; set;}

        public required string Name { get; set; }

        public required string Surname {get; set;}

        public DateOnly Birth {get; set;}

        public ICollection<AuthorBookResponseDTO?>? Books {get; set;}
    }
}