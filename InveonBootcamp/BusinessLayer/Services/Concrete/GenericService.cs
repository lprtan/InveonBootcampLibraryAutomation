using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository) 
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await _genericRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _genericRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entityList = await _genericRepository.GetAllAsync();
            return entityList;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await _genericRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
