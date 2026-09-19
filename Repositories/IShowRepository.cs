using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface IShowRepository
    {
        Task<Show> CreateAsync(Show show);
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
