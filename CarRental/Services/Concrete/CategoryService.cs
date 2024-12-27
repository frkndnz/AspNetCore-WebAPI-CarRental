using AutoMapper;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Category;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;
        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper) : base(genericRepository)
        {
            _mapper = mapper;
            _repository = genericRepository;
        }

        public async Task AddAsync(CreateCategoryDTO createCategoryDTO)
        {
           var category=_mapper.Map<Category>(createCategoryDTO);
            await _repository.TAddAsync(category);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var category = await _repository.TGetByIdAsync(categoryDTO.Id);
            category=_mapper.Map(categoryDTO,category);
            await _repository.TUpdateAsync(category);
        }

        public async Task<List<CategoryDTO>> GetAllDtoAsync()
        {
            var categories=await  _repository.TGetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDTO>>(categories);
            return categoryDtos;
        }

        public async Task<CategoryDTO> GetByIdDtoAsync(int id)
        {
            var category=await  _repository.TGetByIdAsync(id);
            var categoryDto=_mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }
    }
}
