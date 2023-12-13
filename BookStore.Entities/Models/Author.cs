using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Models
{
    public class Author
    {
        public int Id {get; set;}
        public required string Name { get; set; }

        public required string Surname {get; set;}

        public DateOnly Birth {get; set;}


        //* Adding Navigation Properties
        
        public required ICollection<Book> Books {get; set;}
    }
}