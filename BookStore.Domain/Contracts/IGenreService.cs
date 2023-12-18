using BookStore.Domain.Request;
using BookStore.Domain.Response.GenreResponse;

namespace BookStore.Domain.Contracts
{
    public interface IGenreService
    {
        Task<GenreResponseDTO> GetGenreByIdAsync(int genreId, bool trackChanges);

        Task<GenreResponseDTO> CreateGenreAsync(GenreCreateDTO genre);
    }
}