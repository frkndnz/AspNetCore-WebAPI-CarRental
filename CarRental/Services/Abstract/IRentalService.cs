using CarRental.DTO_s.Rental;
using CarRental.DTO_s.User;
using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface IRentalService:IGenericService<Rental>
    {
        public Task<List<RentalDTO>> GetAllDtoAsync();
        public Task<RentalDTO> GetByIdDtoAsync(int id);

        public Task AddDtoAsync(CreateRentalDTO createRentalDTO);

      //  public Task UpdateDtoAsync(UserDTO categoryDTO);

        public Task<decimal> GetTotalPriceAsync(CreateRentalDTO createRentalDTO);
    }
}
