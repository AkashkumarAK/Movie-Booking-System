using MovieBooking.API.DTO.Theater;

namespace MovieBooking.API.Services;

    public interface ITheaterService
    {
        Task<TheaterResponse> CreateAsync(CreateTheaterRequest request);

        Task<TheaterResponse?> GetByIdAsync(int id);

        Task<List<TheaterResponse>> GetAllAsync();

        Task<bool> UpdateAsync(int id, UpdateTheaterRequest request);

        Task<bool> DeleteAsync(int id);
    }
