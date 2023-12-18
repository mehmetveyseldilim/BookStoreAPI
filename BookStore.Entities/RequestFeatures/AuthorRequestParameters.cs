using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.RequestFeatures
{
    public class AuthorRequestParameters : RequestParameters
    {
        public AuthorRequestParameters()
        {
            OrderBy = "Id";
        }

        public string? Name { get; set; } = String.Empty;

        public string? Surname { get; set; } = String.Empty;

        public DateOnly? EndingDate {get; set;} = null;

        public DateOnly? BeginningDate {get; set;} = null;

        public bool IsDateValid() => EndingDate > BeginningDate;

        
    }
}