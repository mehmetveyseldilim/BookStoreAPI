using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;

namespace BookStore.Infrastucture.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsycn(AuthorRequestParameters authorRequestParameters, 
         bool trackChanges);

        Task<Author?> GetAuthorByIdAsync(int authorId, bool trackChanges);

        void CreateAuthor(Author author);

        void DeleteAuthor(Author author);
    }
}