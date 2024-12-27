using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Models;

namespace CarRental.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
