using AutoMapper;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Car;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class CarService : GenericService<Car>,ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        public CarService(ICarRepository genericRepository, IMapper mapper) : base(genericRepository)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateCarDto createCarDto)
        {
            var car=_mapper.Map<Car>(createCarDto);
            await _repository.TAddAsync(car);
        }

        public async Task<List<CarDto>> GetAllDtoAsync()
        {
            var cars=await _repository.GetAllWithInclude();
            var carsDto=_mapper.Map<List<CarDto>>(cars);
            return carsDto;
        }

        public async Task<CarDto> GetByIdDtoAsync(int id)
        {
            var cars=await _repository.GetAllWithInclude();
            var car= cars.FirstOrDefault(c=>c.Id==id);
            return _mapper.Map<CarDto>(car);
        }

        public async Task<List<CarDto>> GetCarsByCategory(int categoryId)
        {
            var cars=await _repository.GetAllWithInclude();
            cars= cars.Where(c=>c.CategoryId==categoryId).ToList();
            return _mapper.Map<List<CarDto>>(cars);
        }

        public async Task UpdateAsync(UpdateCarDto updateCarDto)
        {
            var carEntity = await _repository.TGetByIdAsync(updateCarDto.Id);
            _mapper.Map(updateCarDto,carEntity);
            await _repository.TUpdateAsync(carEntity);
        }
    }
}
