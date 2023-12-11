using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;

namespace BookStore.Infrastucture.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsycn(bool trackChanges);

        Task<Book?> GetBookById(int bookId, bool trackChanges);

        void CreateBook(Book book);

        void DeleteBook(Book book);
    }
}