using CarRental.Data.Abstract;
using CarRental.Data.Repository;
using CarRental.Models;
using CarRental.Services.Abstract;
using CarRental.Services.Concrete;
using CarRental.Services.ValidationRules;
using FluentValidation;



namespace CarRental.Core.Extensions
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

            services.AddScoped(typeof(IRentalService), typeof(RentalService));
            services.AddScoped(typeof(IRentalRepository), typeof(RentalRepository));



            services.AddScoped(typeof(IPdfService), typeof(PdfService));

            services.AddScoped(typeof(IValidator<Car>), typeof(CarValidator));
            services.AddScoped(typeof(IValidator<Category>), typeof(CategoryValidator));
            services.AddScoped(typeof(IValidator<Rental>), typeof(RentalValidator));

            
        }
    }
}
