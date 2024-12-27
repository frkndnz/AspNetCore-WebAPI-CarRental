using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface IGenericService<T> where T:BaseEntity
    {
        public  Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);

        public Task AddAsync(T entity);

        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
