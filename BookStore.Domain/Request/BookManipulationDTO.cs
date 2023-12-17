using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Request
{
    public abstract class BookManipulationDTO
    {
        public required string Title { get; set; }

        public DateOnly ReleaseDate {get; set;}
    }
}