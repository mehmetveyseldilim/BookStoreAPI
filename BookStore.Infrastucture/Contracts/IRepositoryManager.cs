using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Infrastucture.Contracts
{
    public interface IRepositoryManager
    {
        	IBookRepository Books { get; }

            IAuthorRepository Authors {get;}

            IGenreRepository Genres {get;}
	        Task SaveAsync();
    }
}