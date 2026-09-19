using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface ITheaterRepository
    {
        Task<Theater> CreateAsync(Theater theater);

        Task<Theater?> GetByIdAsync(int id);

        Task<List<Theater>> GetAllAsync();

        Task<bool> UpdateAsync(Theater theater);

        Task<bool> DeleteAsync(int id);
    }
