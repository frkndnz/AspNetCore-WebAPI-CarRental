using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
           return await  _context.Users.AnyAsync(u=>u.Email.ToLower()==email.ToLower());
        }
    }
}
