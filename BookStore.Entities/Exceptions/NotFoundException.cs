using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}