using CarRental.Models;

namespace CarRental.Data.Abstract
{
    public interface IRentalRepository:IGenericRepository<Rental>
    {
        public Task<IEnumerable<Rental>> GetAllWithIncludeAsync();
    }
}
