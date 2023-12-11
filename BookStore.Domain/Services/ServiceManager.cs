using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Infrastucture.Contracts;
using Microsoft.Extensions.Logging;

namespace BookStore.Domain.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, mapper));
        }

        public IBookService BookService => _bookService.Value;

    }
}