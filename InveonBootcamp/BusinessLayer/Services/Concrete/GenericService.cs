using BusinessLayer.Services.Abstract;
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
        public GenericService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            await _unitOfWork.DynamicRepository<T>().DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = _unitOfWork.DynamicRepository<T>().GetByIdAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException();
            }

            _unitOfWork.DynamicRepository<T>().DeleteByIdAsync(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entityList = await _unitOfWork.DynamicRepository<T>().GetAllAsync();

            if (entityList == null)
            {
                throw new InvalidOperationException();
            }

            return entityList;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.DynamicRepository<T>().GetByIdAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException();
            }
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var entityId = await _unitOfWork.DynamicRepository<T>().GetByIdAsync(id);

            if (entityId == null)
            {
                throw new InvalidOperationException();
            }

            await _unitOfWork.DynamicRepository<T>().UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
