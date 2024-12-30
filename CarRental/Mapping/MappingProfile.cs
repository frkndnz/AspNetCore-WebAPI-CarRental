using AutoMapper;
using CarRental.DTO_s.Car;
using CarRental.DTO_s.Category;
using CarRental.DTO_s.User;
using CarRental.Models;
using CarRental.ViewModels.UserViewModels;
namespace CarRental.Mapping
{
    public class MappingProfile:Profile
    {
        // create map!
        public MappingProfile() 
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>();

            CreateMap<Car, CarDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
            

            CreateMap<CreateUserViewModel,CreateUserDTO>();
            CreateMap<UpdateUserViewModel,UserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, UserDTO>().ReverseMap();
            
        }
    }
}
