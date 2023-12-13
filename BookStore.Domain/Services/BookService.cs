using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Domain.Request;
using BookStore.Domain.Response;
using BookStore.Domain.Response.BookResponse;
using BookStore.Entities.Exceptions;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Contracts;
using Microsoft.Extensions.Logging;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;


        public BookService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookResponseDTO>> GetAllBooksAsync(BookRequestParameters bookRequestParameters, 
        bool trackChanges, int? foreignAuthorId = null, int? foreignGenreId = null)
        {
            if(bookRequestParameters.IsDateValid) 
            {
                throw new ValidDateException();
            }

            var books = await _repository.Books.GetAllBooksAsycn(bookRequestParameters, trackChanges);

            var booksDTO = _mapper.Map<IEnumerable<BookResponseDTO>>(books);

            return booksDTO;
        }

        public async Task<BookResponseDTO> GetBookByIdAsync(int bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfItExists(bookId, trackChanges);

            var bookDTO = _mapper.Map<BookResponseDTO>(book);

            return bookDTO;
            
        }

        public async Task<BookResponseDTO> CreateBookAsync(BookCreateDTO book)
        {
            var bookEntiy = _mapper.Map<Book>(book);

            _repository.Books.CreateBook(bookEntiy);

            await _repository.SaveAsync();

            var bookToReturn = _mapper.Map<BookResponseDTO>(bookEntiy);

            return bookToReturn;
        }

        public async Task DeleteBookAsync(int bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfItExists(bookId, trackChanges);

            _repository.Books.DeleteBook(book);

            await _repository.SaveAsync();
        }

        public async Task UpdateBookAsync(int bookId, BookUpdateDTO book, bool trackChanges)
        {
            var bookInDb = await GetBookAndCheckIfItExists(bookId, trackChanges);

            _mapper.Map(book, bookInDb);

            await _repository.SaveAsync();

        }

        private async Task<Book> GetBookAndCheckIfItExists(int bookId, bool trackChanges) 
        {
            var book = await _repository.Books.GetBookByIdAsync(bookId, trackChanges);

            if(book is null) 
            {
                throw new BookNotFoundException(bookId);
            }

            return book;
        }
    }
}