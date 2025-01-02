using AutoMapper;
using CarRental.Core.Utilities;
using CarRental.Data.Abstract;
using CarRental.DTO_s.Category;
using CarRental.Models;
using CarRental.Services.Abstract;
using FluentValidation;

namespace CarRental.Services.Concrete
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;
        private readonly IValidator<Category> _validator;
        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper, IValidator<Category> validator) : base(genericRepository)
        {
            _mapper = mapper;
            _repository = genericRepository;
            _validator = validator;
        }

        public async Task<Result> AddAsync(CreateCategoryDTO createCategoryDTO)
        {
           var category=_mapper.Map<Category>(createCategoryDTO);
            var validatorResult= await _validator.ValidateAsync(category);
            if(!validatorResult.IsValid)
                return new Result(false,string.Join("\n",validatorResult.Errors));

            await _repository.TAddAsync(category);
            return new Result(true, "Category added successfully");
        }

        public async Task<Result> UpdateAsync(CategoryDTO categoryDTO)
        {
            var category = await _repository.TGetByIdAsync(categoryDTO.Id);
            if (category == null)
                return new Result(false, "No category found with this Id");

            category=_mapper.Map(categoryDTO,category);
            var validatorResult=await _validator.ValidateAsync(category);
            if (!validatorResult.IsValid)
                return new Result(false, string.Join("\n", validatorResult.Errors.Select(e=>e.ErrorMessage)));

            await _repository.TUpdateAsync(category);
            return new Result(true, "Category updated successfully");
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
