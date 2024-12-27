using AutoMapper;
using CarRental.DTO_s.Car;
using CarRental.DTO_s.Category;
using CarRental.Models;
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
        
        }
    }
}
