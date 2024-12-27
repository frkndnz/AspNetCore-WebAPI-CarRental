using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(Context context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
        }

        public async Task TAddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            ;
            var entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> TGetAllAsync()
        {
            
            return await _dbSet.ToListAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task TUpdateAsync(T entity)
        {
             _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
