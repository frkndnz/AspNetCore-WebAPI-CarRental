using CarRental.Data.Abstract;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class CarService : GenericService<Car>,ICarService
    {
        public CarService(IGenericRepository<Car> genericRepository) : base(genericRepository)
        {

        }
    }
}
