using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(Booking booking);

        Task<List<Booking>> GetAllAsync();

        Task<Booking?> GetByIdAsync(int id);

          Task UpdateAsync(Booking booking);

        Task<List<Seat>> GetSeatsByIdsAsync(List<int> seatIds , int showId);

        Task AddBookingSeatsAsync(List<BookingSeat> bookingSeats);

        Task<List<int>> GetBookedSeatIdsAsync(int showId, List<int> seatIds);
        Task<List<int>> GetAllBookedSeatIdsAsync(int bookingId);
    }
