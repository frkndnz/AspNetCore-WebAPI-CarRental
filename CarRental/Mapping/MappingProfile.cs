using AutoMapper;
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
        }
    }
}
