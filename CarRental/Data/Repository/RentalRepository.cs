using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class RentalRepository : GenericRepository<Rental>,IRentalRepository
    {
        private readonly Context _context;
        public RentalRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetAllWithIncludeAsync()
        {
            var dbset=_context.Set<Rental>();
           var rentals=   await dbset.Include(r=>r.Car).Include(r=>r.User).ToListAsync();
            return rentals;
           
        }
    }
}
