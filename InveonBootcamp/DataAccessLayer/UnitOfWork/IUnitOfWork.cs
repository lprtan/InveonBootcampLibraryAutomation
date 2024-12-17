using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class;
        IGenericRepository<Book> BookRepository { get; }
    }
}
