using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace BookStore.Infrastucture.Extensions.QueryExtensions
{
    public static class AuthorQueryExtensions
    {
        public static IQueryable<Author> FilterAuthors(this IQueryable<Author> authors, AuthorRequestParameters parameters) 
        {
            var filteredByBirthDate = FilterAuthorsByDate(authors, parameters.BeginningDate, parameters.EndingDate);
            var filteredByName = FilterAuthorsByNameCaseInsensitive(filteredByBirthDate, parameters.Name!);
            var filteredBySurname = FilterAuthorsBySurnameCaseInsensitive(filteredByName, parameters.Surname!);

            return filteredBySurname;

        }

        private static IQueryable<Author> FilterAuthorsByDate(IQueryable<Author> authors, DateOnly? begin, DateOnly? end)
        {
            switch ((begin.HasValue, end.HasValue))
            {
                case (true, true):
                    return authors.Where(b => b.Birth >= begin && b.Birth <= end);
                case (true, false):
                    return authors.Where(b => b.Birth >= begin);
                case (false, true):
                    return authors.Where(b => b.Birth <= end);
                default:
                    return authors;
            }
        }

        private static IQueryable<Author> FilterAuthorsByNameCaseInsensitive(IQueryable<Author> authors, string name) 
        {
            if(string.IsNullOrWhiteSpace(name)) 
            {
                return authors;
            }

            return authors.Where(w => EF.Functions.ILike(w.Name, $"%{name}%"));

        }

        private static IQueryable<Author> FilterAuthorsBySurnameCaseInsensitive(IQueryable<Author> authors, string surname) 
        {
            if(string.IsNullOrWhiteSpace(surname)) 
            {
                return authors;
            }

            return authors.Where(w => EF.Functions.ILike(w.Surname, $"%{surname}%"));

        }

        public static IQueryable<Author> Sort(this IQueryable<Author> authors, string orderByQueryString) 
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString)) 
            {
                return authors.OrderBy(x => x.Id);
            }

            var orderQuery = GenericQueryParameterProcessor.CreateOrderQuery<Author>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return authors.OrderBy(e => e.Id);

            return authors.OrderBy(orderQuery);


        }
    }
}