using CarRental.Models;
using CarRental.Services.Abstract;
using CarRental.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories= await _categoryService.GetAllAsync();
            
            if(categories.Any())
            {
                return Ok(categories);
            }
            else
            {
                return BadRequest("Category not found!");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody]Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok();
        }
    }
}
