using MovieBooking.API.DTO.User;

namespace MovieBooking.API.Services;

    public interface IUserService
    {
        Task<UserResponse> CreateAsync(CreateUserRequest dto);
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
