using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Infrastucture.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastucture.Repository
{
    public sealed class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
            
        }

        public Task<bool> CheckIfGenreExistsAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public void CreateGenre(Genre genre)
        {
            Create(genre);
        }

        public async Task<Genre?> GetGenreByIdAsync(int genreId, bool trackChanges)
        {
            var genre = await FindByCondition(b => b.Id == genreId, trackChanges)
                              .SingleOrDefaultAsync();

            return genre;
        }
    }
}