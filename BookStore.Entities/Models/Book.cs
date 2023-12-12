using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Models
{
    public class Book
    {
        public int Id {get; set;}

        public required string Title { get; set; }

        public DateOnly ReleaseDate {get; set;}

        

        //* Navigation Properties

        public int AuthorId {get; set;}

        public required Author Author {get; set;}

        public int GenreId {get; set;}
        public required Genre Genre {get; set;}
    }
}