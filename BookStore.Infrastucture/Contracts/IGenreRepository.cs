using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;

namespace BookStore.Infrastucture.Contracts
{
    public interface IGenreRepository
    {

        Task<Genre?> GetGenreByIdAsync(int genreId, bool trackChanges);

        Task<bool> CheckIfGenreExistsAsync(int genreId);

        void CreateGenre(Genre genre);

    }
}