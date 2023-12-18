using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.Infrastucture.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastucture.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
            protected readonly BookStoreDbContext _repositoryContext;

            public RepositoryBase(BookStoreDbContext repositoryContext)
                => _repositoryContext = repositoryContext;

            public IQueryable<T> FindAll(bool trackChanges) =>
                !trackChanges ?
                _repositoryContext.Set<T>()
                    .AsNoTracking() :
                _repositoryContext.Set<T>();

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
                !trackChanges ? _repositoryContext.Set<T>().Where(expression).AsNoTracking() : _repositoryContext.Set<T>().Where(expression);

            public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

            public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

            public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

    }
}
