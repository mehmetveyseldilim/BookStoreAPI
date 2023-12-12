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
            OrderBy = "id";
        }

        public string? Title { get; set; } = String.Empty;

        public DateOnly? EndingDate {get; set;} = null;

        public DateOnly? BeginningDate {get; set;} = null;

        private bool ValidDateRange => BeginningDate <= EndingDate;


    }
}