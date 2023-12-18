using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Domain.Request;
using BookStore.Domain.Response.GenreResponse;
using BookStore.Entities.Exceptions;
using BookStore.Entities.Models;
using BookStore.Infrastucture.Contracts;
using Microsoft.Extensions.Logging;

namespace BookStore.Domain.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        private readonly ILogger<GenreService> _logger;


        public GenreService(IRepositoryManager repository, IMapper mapper, ILogger<GenreService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenreResponseDTO> CreateGenreAsync(GenreCreateDTO genre)
        {
             var genreEntity = _mapper.Map<Genre>(genre);

            _repository.Genres.CreateGenre(genreEntity);

            await _repository.SaveAsync();

            var genreToReturn = _mapper.Map<GenreResponseDTO>(genreEntity);

            return genreToReturn;
        }

        public async Task<GenreResponseDTO> GetGenreByIdAsync(int genreId, bool trackChanges)
        {
            var genreEntity = await GetGenreIfExists(genreId, trackChanges);

            var genreDTO = _mapper.Map<GenreResponseDTO>(genreEntity);

            return genreDTO;
        }

        private async Task<Genre?> GetGenreIfExists(int genreId, bool trackChanges)
        {
            var genre = await  _repository.Genres.GetGenreByIdAsync(genreId, trackChanges) 
                                ?? throw new GenreNotFound(genreId);
            
            return genre;
        }
    }
}