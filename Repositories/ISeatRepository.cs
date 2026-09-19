using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface ISeatRepository
    {
        Task<Seat> CreateAsync(Seat seat);
        Task<List<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
