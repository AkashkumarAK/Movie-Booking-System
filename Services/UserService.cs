using MovieBooking.API.DTO.User;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateAsync(CreateUserRequest dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            var createdUser = await _userRepository.CreateAsync(user);

            return new UserResponse
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email
            };
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserResponse?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
