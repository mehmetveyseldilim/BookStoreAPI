using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Request
{
    public class BookCreateDTO : BookManipulationDTO
    {
        public int AuthorId {get; set;}

        public int GenreId {get; set;}
    }
}