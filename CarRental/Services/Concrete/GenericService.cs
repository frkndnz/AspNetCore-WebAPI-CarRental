using CarRental.Data.Abstract;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T: BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> genericRepository )
        {
            _repository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
             await _repository.TAddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.TGetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.TGetByIdAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
