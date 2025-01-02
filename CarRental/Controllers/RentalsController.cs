using AutoMapper;
using CarRental.DTO_s.Rental;
using CarRental.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRentalService _rentalService;
        private readonly IPdfService _pdfService;
        public RentalsController(IMapper mapper, IRentalService rentalService, IPdfService pdfService)
        {
            _mapper = mapper;
            _rentalService = rentalService;
            _pdfService = pdfService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllDtoAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalService.GetByIdDtoAsync(id);
            if (rental == null)
            {
                return NotFound("rental not found!");
            }
            else
            {
                return Ok(rental);
            }

        }
        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetRentalPdf(int id)
        {
            var rental = await _rentalService.GetByIdDtoAsync(id);
            if (rental == null)
            {
                return NotFound("rental not found!");
            }
            else
            {
                var pdfBytes = await _pdfService.GenerateRentalPdfAsync(rental);
                return File(pdfBytes, "application/pdf", $"rental_{id}.pdf");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRental(CreateRentalDTO createRentalDTO)
        {
            var result = await _rentalService.AddDtoAsync(createRentalDTO);
            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
