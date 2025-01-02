using CarRental.Core.Utilities;
using CarRental.DTO_s.Category;
using CarRental.Models;
using CarRental.Services.Abstract;
using CarRental.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _categoryService.GetAllDtoAsync();

            if (categories.Any())
            {
                return Ok(categories);
            }
            else
            {
                return BadRequest("Category not found!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByIdDtoAsync(id);
            if (category == null)
            {
                return BadRequest("Category not found!");
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var result = await _categoryService.AddAsync(createCategoryDTO);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.UpdateAsync(categoryDTO);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok("Successfully");
        }

    }
}
