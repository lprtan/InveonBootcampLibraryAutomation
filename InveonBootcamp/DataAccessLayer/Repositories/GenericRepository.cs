using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbcontext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entityId = await _dbcontext.Set<T>().FindAsync(id);
            await DeleteAsync(entityId);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
        }
    }
}
