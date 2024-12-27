using CarRental.Models;
using CarRental.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController:ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars=await _carService.GetAllAsync();

            if (cars == null || !cars.Any()) 
            {
                return NotFound("No cars found!");
            }
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            await _carService.AddAsync(car);
            return Ok();
        }
    }
}
