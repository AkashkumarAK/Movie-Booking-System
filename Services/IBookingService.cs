using MovieBooking.API.DTO.Booking;

namespace MovieBooking.API.Services;

    public interface IBookingService
    {
         Task<BookingResponse> CreateAsync(
        int userId,
        CreateBookingRequest request);

       // Task<BookingResponse> CreateAsync(CreateBookingRequest dto);

        Task<List<BookingResponse>> GetAllAsync();

        Task<BookingResponse?> GetByIdAsync(int id);

        Task<bool> CancelBookingAsync(int bookingId);
    }
