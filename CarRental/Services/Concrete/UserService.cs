using AutoMapper;
using CarRental.Core.Utilities;
using CarRental.Data.Abstract;
using CarRental.DTO_s.User;
using CarRental.Models;
using CarRental.Services.Abstract;
using FluentValidation;

namespace CarRental.Services.Concrete
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<User> _validator;
        public UserService(IUserRepository genericRepository, IMapper mapper, IValidator<User> validator) : base(genericRepository)
        {
            _repository = genericRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result> AddAsync(CreateUserDTO createCategoryDTO)
        {
            var user= _mapper.Map<User>(createCategoryDTO);

            if (await _repository.IsEmailTakenAsync(user.Email))
                return new Result(false, "Email already taken");
            

            var validatorResult= await _validator.ValidateAsync(user);

            if(!validatorResult.IsValid) 
                return new Result(false,string.Join("\n",validatorResult.Errors.Select(e=>e.ErrorMessage)));

            await _repository.TAddAsync(user);
            return new Result(true, "Added user successfully!");
        }

        public async Task<List<UserDTO>> GetAllDtoAsync()
        {
            var users=await _repository.TGetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByIdDtoAsync(int id)
        {
            var user=await _repository.TGetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateAsync(UserDTO userDto)
        {
            var userEntity = await _repository.TGetByIdAsync(userDto.Id);
            _mapper.Map(userDto, userEntity);
            await _repository.TUpdateAsync(userEntity);
        }
    }
}
