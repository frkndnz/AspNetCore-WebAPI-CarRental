using AutoMapper;
using CarRental.Core.Utilities;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Car;
using CarRental.Models;
using CarRental.Services.Abstract;
using FluentValidation;

namespace CarRental.Services.Concrete
{
    public class CarService : GenericService<Car>,ICarService
    {
        private readonly ICarRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Car> _validator;
        public CarService(ICarRepository genericRepository, IMapper mapper, IValidator<Car> validator, ICategoryRepository categoryRepository) : base(genericRepository)
        {
            _repository = genericRepository;
            _mapper = mapper;
            _validator = validator;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> AddAsync(CreateCarDto createCarDto)
        {
            var car=_mapper.Map<Car>(createCarDto);

            var category = await _categoryRepository.TGetByIdAsync(car.CategoryId);
            if (category == null)
                return new Result(false, "İlgili category bulunamadı !");

            var validationResult=_validator.Validate(car);
            if (!validationResult.IsValid)
            {
                return new Result(false,string.Join("\n",validationResult.Errors.Select(e=>e.ErrorMessage)));
            }
            await _repository.TAddAsync(car);
            return new Result(true, "Arac basarıyla eklendi!");
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

        public async Task<Result> UpdateAsync(UpdateCarDto updateCarDto)
        {
            var carEntity = await _repository.TGetByIdAsync(updateCarDto.Id);
            if (carEntity == null)
                return new Result(false, "belirtilen Id'ye sahip araç bulunamadı!");
            _mapper.Map(updateCarDto,carEntity);

            var validationResult=_validator.Validate(carEntity);
            if(!validationResult.IsValid)
            {
                return new Result(false, string.Join("\n", validationResult.Errors));
            }
            await _repository.TUpdateAsync(carEntity);
            return new Result(true, "Arac basarıyla güncellendi!");
        }
    }
}
