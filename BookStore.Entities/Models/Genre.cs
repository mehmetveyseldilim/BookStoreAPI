using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Models
{
    public class Genre
    {
        public int Id {get; set;}
        public required string Name { get; set; }
        //* Adding Navigation Properties
        public required ICollection<Book> Books {get; set;}
    }
}