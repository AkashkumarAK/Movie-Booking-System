using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface IScreenRepository
    {
        Task<Screen> CreateAsync(Screen screen);

        Task<Screen?> GetByIdAsync(int id);

        Task<List<Screen>> GetAllAsync();

        Task<List<Screen>> GetByTheaterIdAsync(int theaterId);

        Task<bool> UpdateAsync(Screen screen);

        Task<bool> DeleteAsync(int id);
    }
