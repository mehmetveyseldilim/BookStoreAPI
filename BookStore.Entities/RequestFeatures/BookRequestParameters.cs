using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Entities.RequestFeatures
{
    public class BookRequestParameters : RequestParameters
    {
        public BookRequestParameters()
        {
            OrderBy = "Title";
        }

        public DateOnly EndingDate {get; set;} = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly BeginningDate {get; set;} = DateOnly.FromDateTime(DateTime.MinValue);

        [JsonIgnore]
        //[BindNever]
        public bool ValidDateRange => BeginningDate <= EndingDate;


    }
}