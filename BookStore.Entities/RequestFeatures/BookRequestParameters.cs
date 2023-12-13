
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

        public bool IsDateValid() => EndingDate > BeginningDate;


    }
}