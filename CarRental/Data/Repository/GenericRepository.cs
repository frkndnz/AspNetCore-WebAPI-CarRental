using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public Task<List<T>> TGetAllAsync()
        {
            var dbSet = _context.Set<T>();
            return dbSet.ToListAsync();
        }

        public Task<T> TGetByIdAsync(int id)
        {
            var dbSet = _context.Set<T>();
            return dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
