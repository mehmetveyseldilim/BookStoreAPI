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


        public RepositoryManager(BookStoreDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
        }


        public IBookRepository Books => _bookRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}