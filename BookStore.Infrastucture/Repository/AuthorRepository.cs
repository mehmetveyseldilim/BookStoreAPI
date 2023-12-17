using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Contracts;

namespace BookStore.Infrastucture.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
            
        }
        
        public void CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsycn(AuthorRequestParameters authorRequestParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Author?> GetAuthorByIdAsync(int authorId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}