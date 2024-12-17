using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IGenericRepository<Book> BookRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext) 
        {
            _dbContext = dbContext;

            BookRepository = new GenericRepository<Book>(_dbContext);
        }

        public IGenericRepository<T> DynamicRepository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public async Task SaveAsync()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
