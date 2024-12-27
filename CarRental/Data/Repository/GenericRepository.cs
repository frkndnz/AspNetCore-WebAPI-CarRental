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

        public async Task TAddAsync(T entity)
        {
            var dbSet=_context.Set<T>();
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task TDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> TGetAllAsync()
        {
            var dbSet = _context.Set<T>();
            return await dbSet.ToListAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            var dbSet = _context.Set<T>();
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task TUpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
