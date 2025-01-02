using CarRental.Core.Utilities;
using CarRental.DTO_s.Car;
using CarRental.DTO_s.Category;
using CarRental.Models;
using CarRental.Services.Concrete;

namespace CarRental.Services.Abstract
{
    public interface ICarService:IGenericService<Car>
    {
        public Task<List<CarDto>> GetAllDtoAsync();
        public Task<CarDto> GetByIdDtoAsync(int id);
        public Task<List<CarDto>> GetCarsByCategory(int categoryId);

        public Task<Result> AddAsync(CreateCarDto createCarDto);

        public Task<Result> UpdateAsync(UpdateCarDto updateCarDto);
    }
}
