using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;

namespace BookStore.Domain.Response.BookResponse
{
    public class BookResponseDTO
    {
        public int Id {get; set;}

        public required string Title { get; set; }

        public DateOnly ReleaseDate {get; set;}

        //* Navigation Properties

        public BookAuthorResponseDTO? Author {get; set;}

        public BookGenreResponseDTO? Genre {get; set;}
    }
}