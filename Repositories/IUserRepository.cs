using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }