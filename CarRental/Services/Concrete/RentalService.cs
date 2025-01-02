using AutoMapper;
using CarRental.Core.Utilities;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Rental;
using CarRental.Models;
using CarRental.Services.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarRental.Services.Concrete
{
    public class RentalService : GenericService<Rental>, IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Rental> _validator;
        public RentalService(IRentalRepository genericRepository, IGenericRepository<Car> carRepository, IMapper mapper, IValidator<Rental> validator, IUserRepository userRepository) : base(genericRepository)
        {
            _rentalRepository = genericRepository;
            _carRepository = carRepository;
            _mapper = mapper;
            _validator = validator;
            _userRepository = userRepository;
        }

        public async Task<Result> AddDtoAsync(CreateRentalDTO createRentalDTO)
        {
            var rentalEntity = _mapper.Map<Rental>(createRentalDTO);

            var user=await _userRepository.TGetByIdAsync(rentalEntity.UserId);
            if (user == null) return new Result(false, "user not found!");

            var car = await _carRepository.TGetByIdAsync(rentalEntity.CarId);
            if (car == null) return new Result(false,"car not found!");

            var validatorResult=await _validator.ValidateAsync(rentalEntity);
            if(!validatorResult.IsValid)
                return new Result(false,string.Join("\n",validatorResult.Errors.Select(e=>e.ErrorMessage)));

            rentalEntity.Price = await GetTotalPriceAsync(createRentalDTO);
            await _rentalRepository.TUpdateAsync(rentalEntity);
            return new Result(true, "Added rental successfully");
        }

        public async Task<List<RentalDTO>> GetAllDtoAsync()
        {
            var rentals = await _rentalRepository.GetAllWithIncludeAsync();
            var rentalsDtos = _mapper.Map<List<RentalDTO>>(rentals);
            return rentalsDtos;
        }

        public async Task<RentalDTO> GetByIdDtoAsync(int id)
        {
            var rentals = await _rentalRepository.GetAllWithIncludeAsync();
            var rental = rentals.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task<decimal> GetTotalPriceAsync(CreateRentalDTO createRentalDTO)
        {
            var car = await _carRepository.TGetByIdAsync(createRentalDTO.CarId);
            if (car == null)
            {
                throw new ArgumentException("Car not found!");
            }
            else
            {
                DateTime start = createRentalDTO.RentalStartDate;
                DateTime end = createRentalDTO.RentalEndDate;

                int rentalDays = (end - start).Days;
                decimal dailyCarPrice = car.Price;

                decimal totalPrice = dailyCarPrice * rentalDays;
                return totalPrice;
            }
        }


    }
}
