using CarRental.DTO_s.Car;
using CarRental.Models;
using CarRental.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllDtoAsync();

            if (cars == null || !cars.Any())
            {
                return NotFound("No cars found!");
            }
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetByIdDtoAsync(id);
            if (car == null)
            {
                return NotFound("Car not found!");
            }
            else
            {
                return Ok(car);
            }
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetCarsByCategory([FromQuery] int id)
        {
            var cars= await _carService.GetCarsByCategory(id);
            if (cars == null || !cars.Any())
            {
                return NotFound("Cars not found!");
            }
            else
            {
                return Ok(cars);

            };
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarDto createCarDto)
        {
           var result= await _carService.AddAsync(createCarDto);
            if(result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDto updateCarDto)
        {
            var result= await _carService.UpdateAsync(updateCarDto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteAsync(id);
            return Ok();
        }
    }
}
