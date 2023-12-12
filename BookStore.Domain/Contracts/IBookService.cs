using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Request;
using BookStore.Domain.Response;
using BookStore.Domain.Response.BookResponse;
using BookStore.Entities.RequestFeatures;

namespace BookStore.Domain.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDTO>> GetAllBooksAsync(BookRequestParameters bookRequestParameters, 
        bool trackChanges, int? foreignAuthorId = null, int? foreignGenreId = null);

        Task<BookResponseDTO> GetBookByIdAsync(int bookId, bool trackChanges);

        Task<BookResponseDTO> CreateBookAsync(BookCreateDTO book);

        Task DeleteBookAsync(int bookId, bool trackChanges);

        Task UpdateBookAsync(int bookId, BookUpdateDTO book, bool trackChanges);
    }
}