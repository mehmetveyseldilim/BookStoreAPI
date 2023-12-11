using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService {get;}
    }
}