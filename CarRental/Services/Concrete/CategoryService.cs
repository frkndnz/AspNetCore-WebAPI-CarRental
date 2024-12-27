using CarRental.Data.Abstract;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> genericRepository) : base(genericRepository)
        {
        }
    }
}
