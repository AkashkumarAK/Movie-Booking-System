using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.User;
using MovieBooking.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace MovieBooking.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest dto)
        {
            var user = await _userService.CreateAsync(dto);

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteAsync(id);

            if (!deleted)
                return NotFound("User not found");

            return Ok("User deleted successfully");
        }
    }
