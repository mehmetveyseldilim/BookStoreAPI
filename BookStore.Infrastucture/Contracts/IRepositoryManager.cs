using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Infrastucture.Contracts
{
    public interface IRepositoryManager
    {
        	IBookRepository Book { get; }
	        Task SaveAsync();
    }
}