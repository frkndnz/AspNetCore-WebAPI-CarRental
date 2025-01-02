using CarRental.Models;

namespace CarRental.Data.Abstract
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public Task<bool> IsEmailTakenAsync(string email);
    }
}
