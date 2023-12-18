using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public class AuthorNotFound : BadRequestException
    {
        public AuthorNotFound(int id) : base($"Author with id {id} does not exist in the database")
        {
            
        }
    }
}