using AutoMapper;
using CarRental.Data.Abstract;
using CarRental.DTO_s.User;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> genericRepository, IMapper mapper) : base(genericRepository)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateUserDTO createCategoryDTO)
        {
            var user= _mapper.Map<User>(createCategoryDTO);
            await _repository.TAddAsync(user);
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
