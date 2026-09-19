using MovieBooking.API.DTO.Screen;

namespace MovieBooking.API.Services;

    public interface IScreenService
    {
        Task<ScreenResponse> AddScreenAsync(CreateScreenRequest dto);
        Task<List<ScreenResponse>> GetScreensAsync();
        Task<ScreenResponse?> GetScreenByIdAsync(int id);
        Task<bool> DeleteScreenAsync(int id);
    }
