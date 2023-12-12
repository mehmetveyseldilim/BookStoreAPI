using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastucture.Repository
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
            
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsycn(BookRequestParameters bookRequestParameters, bool trackChanges)
        {
            var books =  await FindAll(trackChanges: trackChanges).ToListAsync();



            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int bookId, bool trackChanges)
        {
            var book = await FindByCondition(b => b.Id == bookId, trackChanges)
                        .Include(y => y.Author)
                        .Include(y => y.Genre)
                        .SingleOrDefaultAsync();

            return book;
        }

        public void CreateBook(Book book) => Create(book);


        public void DeleteBook(Book book) => Delete(book);


    }
}