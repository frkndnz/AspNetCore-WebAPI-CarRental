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
        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.TGetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.TGetByIdAsync(id);
        }
    }
}
