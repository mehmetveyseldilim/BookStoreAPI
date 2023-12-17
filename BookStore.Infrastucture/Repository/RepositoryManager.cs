using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastucture.Contracts;

namespace BookStore.Infrastucture.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly BookStoreDbContext _repositoryContext;
        private readonly Lazy<IBookRepository> _bookRepository;

        private readonly Lazy<IAuthorRepository> _authorRepository;

        private readonly Lazy<IGenreRepository> _genreRepository;


        public RepositoryManager(BookStoreDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
            _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(repositoryContext));
        }


        public IBookRepository Books => _bookRepository.Value;

        public IAuthorRepository Authors => _authorRepository.Value;

        public IGenreRepository Genres => _genreRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}