using AutoMapper;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Rental;
using CarRental.Models;
using CarRental.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarRental.Services.Concrete
{
    public class RentalService : GenericService<Rental>, IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IMapper _mapper;
        public RentalService(IRentalRepository genericRepository, IGenericRepository<Car> carRepository, IMapper mapper) : base(genericRepository)
        {
            _rentalRepository = genericRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task AddDtoAsync(CreateRentalDTO createRentalDTO)
        {
            var rentalEntity = _mapper.Map<Rental>(createRentalDTO);
            rentalEntity.Price = await GetTotalPriceAsync(createRentalDTO);
            await _rentalRepository.TUpdateAsync(rentalEntity);
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
