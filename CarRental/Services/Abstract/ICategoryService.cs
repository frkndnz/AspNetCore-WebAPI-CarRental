using CarRental.DTO_s.Category;
using CarRental.Models;

namespace CarRental.Services.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public Task<List<CategoryDTO>> GetAllDtoAsync();
        public Task<CategoryDTO> GetByIdDtoAsync(int id);

        public Task AddAsync(CreateCategoryDTO  createCategoryDTO);

        public Task UpdateAsync(CategoryDTO categoryDTO);
        
    }
}
