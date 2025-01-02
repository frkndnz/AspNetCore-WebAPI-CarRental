using CarRental.Core.Utilities;
using CarRental.DTO_s.Category;
using CarRental.DTO_s.User;
using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface IUserService:IGenericService<User>
    {
        public Task<List<UserDTO>> GetAllDtoAsync();
        public Task<UserDTO> GetByIdDtoAsync(int id);

        public Task<Result> AddAsync(CreateUserDTO createCategoryDTO);

        public Task UpdateAsync(UserDTO categoryDTO);
    }
}
