using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface IGenericService<T> where T:BaseEntity
    {
        public  Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
