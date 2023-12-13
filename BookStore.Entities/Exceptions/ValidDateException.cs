using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public class ValidDateException : BadRequestException
    {
        public ValidDateException() : base("End date can't be less than beginning date")
        {
            
        }
    }
}