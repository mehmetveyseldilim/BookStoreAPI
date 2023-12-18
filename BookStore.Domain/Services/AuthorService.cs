using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Domain.Request;
using BookStore.Domain.Response.AuthorResponse;
using BookStore.Entities.Exceptions;
using BookStore.Entities.RequestFeatures;
using BookStore.Infrastucture.Contracts;
using Microsoft.Extensions.Logging;

namespace BookStore.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;

        private readonly ILogger<AuthorService> _logger;
        private readonly IMapper _mapper;


        public AuthorService(IRepositoryManager repository, IMapper mapper, ILogger<AuthorService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<AuthorResponseDTO> CreateBookAsync(AuthorCreateDTO author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorAsync(int authorId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuthorResponseDTO>> GetAllAuthorsAsync(AuthorRequestParameters authorRequestParameters, bool trackChanges)
        {
            if(authorRequestParameters.IsDateValid()) 
            {
                throw new ValidDateException();
            }

            var authors = await _repository.Authors.GetAllAuthorsAsycn(authorRequestParameters, trackChanges);

            var authorsDTO = _mapper.Map<IEnumerable<AuthorResponseDTO>>(authors);

            return authorsDTO;
        }

        public Task<AuthorResponseDTO> GetAuthorsByIdAsync(int authorId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(int authorId, AuthorUpdateDTO author, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}