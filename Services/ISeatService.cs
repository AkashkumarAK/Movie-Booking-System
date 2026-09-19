using MovieBooking.API.DTO.Seats;

namespace MovieBooking.API.Services;

    public interface ISeatService
    {
        Task<SeatResponse> CreateAsync(CreateSeatRequest dto);
        Task<List<SeatResponse>> GetAllAsync();
        Task<SeatResponse?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
