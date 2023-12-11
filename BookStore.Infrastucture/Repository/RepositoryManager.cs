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


        public RepositoryManager(BookStoreDbContext repositoryContext, Lazy<IBookRepository> bookRepository)
        {
            _repositoryContext = repositoryContext;
            _bookRepository = bookRepository;
        }


        public IBookRepository Book => _bookRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}