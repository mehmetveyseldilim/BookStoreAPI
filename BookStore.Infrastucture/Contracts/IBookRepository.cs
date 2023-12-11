using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;

namespace BookStore.Infrastucture.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsycn(BookRequestParameters bookRequestParameters, bool trackChanges);

        Task<Book?> GetBookByIdAsync(int bookId, bool trackChanges);

        void CreateBook(Book book);

        void DeleteBook(Book book);
    }
}