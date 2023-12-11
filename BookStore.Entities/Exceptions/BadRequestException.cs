using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public abstract  class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {

        }
    }
}