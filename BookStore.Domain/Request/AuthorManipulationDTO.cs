using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Request
{
    public abstract class AuthorManipulationDTO
    {
        public required string Name { get; set; }

        public required string Surname {get; set;}

        public DateOnly Birth {get; set;}   
    }
}