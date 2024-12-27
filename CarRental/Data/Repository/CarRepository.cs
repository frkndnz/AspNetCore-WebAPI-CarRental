using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly Context _context;
        public CarRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllWithInclude()
        {
            var dbSet=_context.Set<Car>();
            var cars= await dbSet.Include(c=>c.Category).ToListAsync();
            return cars; 
        }
    }
}
