using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;

namespace CarRental.Data.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(Context context) : base(context)
        {
        }
    }
}
