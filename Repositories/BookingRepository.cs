using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.SqlClient;

namespace MovieBooking.API.Repositories;

    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        // Create Booking
        public async Task<Booking> CreateAsync(Booking booking)
        {
            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return booking;
        }

        // Get all Bookings
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);

            await _context.SaveChangesAsync();
        }

       
       
        public async Task<List<Seat>> GetSeatsByIdsAsync(List<int> seatIds, int showId)
        {
            int screenid = await _context.Shows
                .Where(s => s.Id == showId)
                .Select(s => s.ScreenId)
                .FirstOrDefaultAsync();

            return await _context.Seats
                .Where(s => seatIds.Contains(s.Id) && s.ScreenId == screenid)
                .ToListAsync();
        }

        public async Task AddBookingSeatsAsync(
            List<BookingSeat> bookingSeats)
        {
            _context.BookingSeats.AddRange(bookingSeats);

            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetBookedSeatIdsAsync(
            int showId,
            List<int> seatIds)
        {
            return await _context.BookingSeats
                .Where(bs =>
                    seatIds.Contains(bs.SeatId) &&
                    bs.Booking.ShowId == showId &&
                    bs.Booking.Status == "Confirmed")
                .Select(bs => bs.SeatId)
                .ToListAsync();
        }

        public async Task<List<int>> GetAllBookedSeatIdsAsync(int bookingId)
        {
            return await _context.BookingSeats
                .Where(bs => bs.BookingId == bookingId)
                .Select(bs => bs.SeatId)
                .ToListAsync();
        }

        public async Task AcquireSeatLockAsync(int showId, int seatId)
        {
            var resource = 
                $"MovieBooking:Show:{showId}:Seat:{seatId}";

            var resourceParameter = new SqlParameter("@Resource", resource);

            var resultParameter = new SqlParameter("@Result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                """
                EXEC @Result = sp_getapplock
                    @Resource = @Resource,
                    @LockMode = 'Exclusive',
                    @LockOwner = 'Transaction',
                    @LockTimeout = 10000;
                """,
                resultParameter,
                resourceParameter);

            var result = (int)resultParameter.Value;

            if (result < 0)
            {
                throw new InvalidOperationException(
                    $"Could not acquire lock for Show {showId}, Seat {seatId}. " +
                    $"SQL lock result: {result}");
            }
        }
    }
      