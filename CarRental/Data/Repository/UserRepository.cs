using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;

namespace CarRental.Data.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
