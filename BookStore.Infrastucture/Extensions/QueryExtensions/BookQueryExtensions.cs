using System.Linq.Dynamic.Core;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastucture.Extensions.QueryExtensions
{
    public static class BookQueryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, BookRequestParameters bookRequestParameters) 
        {
            var filteredByTitle = FilterBooksByTitleCaseInsensitive(books, bookRequestParameters.Title!);
            var filteredByDate = FilterBooksByDate(filteredByTitle, bookRequestParameters.BeginningDate, bookRequestParameters.EndingDate);
           
            
            return filteredByDate;
        } 

        public static IQueryable<Book> FilterBooksByForeignAuthorId(this IQueryable<Book> books, int? foreighAuthorId) 
        {
            if(foreighAuthorId.HasValue) 
            {
                return books.Where(w => w.AuthorId == foreighAuthorId);
            }

            return books;
            
        }

        public static IQueryable<Book> FilterBooksByForeignGenreId(this IQueryable<Book> books, int? foreignGenreId) 
        {
            if(foreignGenreId.HasValue) 
            {
                return books.Where(w => w.GenreId == foreignGenreId);
            }

            return books;
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString) 
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString)) 
            {
                return books.OrderBy(x => x.Id);
            }

            

            var orderQuery = GenericQueryParameterProcessor.CreateOrderQuery<Book>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return books.OrderBy(e => e.Id);

            return books.OrderBy(orderQuery);


        }

        private static IQueryable<Book> FilterBooksByDate(IQueryable<Book> books, DateOnly? begin, DateOnly? end)
        {
            switch ((begin.HasValue, end.HasValue))
            {
                case (true, true):
                    return books.Where(b => b.ReleaseDate >= begin && b.ReleaseDate <= end);
                case (true, false):
                    return books.Where(b => b.ReleaseDate >= begin);
                case (false, true):
                    return books.Where(b => b.ReleaseDate <= end);
                default:
                    return books;
            }
        }


        private static IQueryable<Book> FilterBooksByTitleCaseInsensitive(IQueryable<Book> books, string title) 
        {
            if(string.IsNullOrWhiteSpace(title)) 
            {
                return books;
            }

            return books.Where(w => EF.Functions.ILike(w.Title, $"%{title}%"));


        }

        private static IQueryable<Book> FilterBooksByTitle(IQueryable<Book> books, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return books;
            }

            return books.Where(w => EF.Functions.Like(w.Title, $"%{title}%"));
        }







    }
}