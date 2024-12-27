using CarRental.Models;

namespace CarRental.Data.Abstract
{
    public interface ICarRepository:IGenericRepository<Car>
    {
        public Task<IEnumerable<Car>> GetAllWithInclude();
    }
}
