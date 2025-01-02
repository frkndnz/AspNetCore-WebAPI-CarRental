using AutoMapper;
using CarRental.DTO_s.User;
using CarRental.Services.Abstract;
using CarRental.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllDtoAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdDtoAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var createUserDto = _mapper.Map<CreateUserDTO>(viewModel);
                var result= await _userService.AddAsync(createUserDto);

                if(!result.IsSuccess)
                    return BadRequest(result.Message);

                return Ok(result.Message);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest
                    (new
                    {
                        Message = "Validation errors!",
                        Errors = errors
                    }
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UserDTO>(viewModel);
                await _userService.UpdateAsync(userDto);
                return Ok(userDto);
            }
            else 
            {
                var errors=ModelState.Values.SelectMany(v => v.Errors) .Select(e => e.ErrorMessage).ToList();

                return BadRequest(new
                {
                    Message = "Validation failed!",
                    Errors = errors
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
