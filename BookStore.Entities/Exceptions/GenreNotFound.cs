using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public class GenreNotFound : BadRequestException
    {
        public GenreNotFound(int id) : base($"Genre with id {id} does not exist in the database")
        {
            
        }
    }
}