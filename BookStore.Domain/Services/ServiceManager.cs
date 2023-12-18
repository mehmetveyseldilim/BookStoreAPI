using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Entities.Models;
using BookStore.Infrastucture.Contracts;
using Microsoft.Extensions.Logging;

namespace BookStore.Domain.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IGenreService> _genreService;
        private readonly Lazy<IAuthorService> _authorService;



        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
        ILogger<AuthorService> logger, ILogger<BookService> logger1, ILogger<GenreService> logger2)
        {
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, mapper, logger1));
            _genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager, mapper, logger2));
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager, mapper, logger));
        }

        public IBookService BookService => _bookService.Value;

        public IGenreService GenreService => _genreService.Value;

        public IAuthorService AuthorService => _authorService.Value;

    }
}