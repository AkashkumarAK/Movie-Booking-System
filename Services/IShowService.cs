using MovieBooking.API.DTO.Show;

namespace MovieBooking.API.Services;

    public interface IShowService
    {
        Task<ShowResponse> CreateAsync(CreateShowRequest dto);
        Task<List<ShowResponse>> GetAllAsync();
        Task<ShowResponse?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
