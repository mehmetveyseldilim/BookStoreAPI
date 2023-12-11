using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with id: {id} does not exist in the database")
        {
            
        }
    }
}