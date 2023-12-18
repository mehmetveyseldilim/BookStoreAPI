using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Request;
using BookStore.Domain.Response.AuthorResponse;
using BookStore.Entities.RequestFeatures;

namespace BookStore.Domain.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseDTO>> GetAllAuthorsAsync(AuthorRequestParameters authorRequestParameters, 
        bool trackChanges);

        Task<AuthorResponseDTO> GetAuthorsByIdAsync(int authorId, bool trackChanges);

        Task<AuthorResponseDTO> CreateBookAsync(AuthorCreateDTO author);

        Task DeleteAuthorAsync(int authorId, bool trackChanges);

        Task UpdateAuthorAsync(int authorId, AuthorUpdateDTO author, bool trackChanges);
    }
}