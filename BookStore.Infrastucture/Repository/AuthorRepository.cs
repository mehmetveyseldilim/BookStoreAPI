using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Contracts;
using BookStore.Infrastucture.Extensions.QueryExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace BookStore.Infrastucture.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
            
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsycn(AuthorRequestParameters authorRequestParameters, bool trackChanges)
        {
            var authors =   await FindAll(trackChanges)
                            .FilterAuthors(authorRequestParameters)
                            .Sort(authorRequestParameters.OrderBy!)
                            .ToListAsync();
                            
            return authors;
        }

        public async Task<Author?> GetAuthorByIdAsync(int authorId, bool trackChanges)
        {
            var author = await FindByCondition(a => a.Id == authorId, trackChanges)
                                .Include(a => a.Books)
                                .SingleOrDefaultAsync();

            return author;
        }

        public async Task<bool> CheckIfAuthorExistsAsync(int authorId)
        {
            bool doesAuthorExist = await _repositoryContext.Authors.AnyAsync(x => x.Id == authorId);

            return doesAuthorExist;
        }

        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void DeleteAuthor(Author author)
        {
            Delete(author);
        }


    }
}