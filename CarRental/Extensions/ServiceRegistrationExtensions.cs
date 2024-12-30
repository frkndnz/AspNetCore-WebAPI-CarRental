using CarRental.Data.Abstract;
using CarRental.Data.Repository;
using CarRental.Services.Abstract;
using CarRental.Services.Concrete;

namespace CarRental.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped(typeof(ICarService), typeof(CarService));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));

            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
