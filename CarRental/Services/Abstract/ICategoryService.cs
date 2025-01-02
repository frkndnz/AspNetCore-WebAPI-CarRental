using CarRental.Core.Utilities;
using CarRental.DTO_s.Category;
using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public Task<List<CategoryDTO>> GetAllDtoAsync();
        public Task<CategoryDTO> GetByIdDtoAsync(int id);

        public Task<Result> AddAsync(CreateCategoryDTO  createCategoryDTO);

        public Task<Result> UpdateAsync(CategoryDTO categoryDTO);
        
    }
}
