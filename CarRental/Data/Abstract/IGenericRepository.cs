using CarRental.Models;

namespace CarRental.Data.Abstract
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        public  Task<List<T>> TGetAllAsync();
        public Task<T> TGetByIdAsync(int id);

        public Task TAddAsync(T entity);
        public Task TUpdateAsync(T entity);
        public Task TDeleteAsync(int id);
    }
}
