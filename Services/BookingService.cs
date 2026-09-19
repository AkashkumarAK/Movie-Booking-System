using MovieBooking.API.DTO.Booking;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository  )
        {
            _bookingRepository = bookingRepository;
        }

 
        public async Task<BookingResponse> CreateAsync(int user_id,
            CreateBookingRequest dto)
        {
            var seats = await _bookingRepository.GetSeatsByIdsAsync(dto.SeatIds, dto.ShowId);

            if (seats.Count != dto.SeatIds.Count)
            {
              throw new Exception("One or more seat IDs are invalid.");
           }
            // 1. Check if selected seats are already booked
            var bookedSeatIds = await _bookingRepository
                .GetBookedSeatIdsAsync(
                    dto.ShowId,
                    dto.SeatIds);

            if (bookedSeatIds.Any())
            {
                throw new InvalidOperationException(
                    $"The following seats are already booked: " +
                    $"{string.Join(", ", bookedSeatIds)}");
            }

            // 2. Get selected seats---stored in seats variable
          //  var seats = await _bookingRepository
            //    .GetSeatsByIdsAsync(dto.SeatIds);

            // 3. Calculate total price
            var totalAmount = seats.Sum(s => s.Price);

            // 4. Create Booking
            var booking = new Booking
            {
                UserId = user_id,
                ShowId = dto.ShowId,
                BookingDate = DateTime.UtcNow,
                TotalAmount = totalAmount,
                Status = "Confirmed"
            };

            var createdBooking = await _bookingRepository
                .CreateAsync(booking);

            // 5. Create BookingSeat records
            var bookingSeats = dto.SeatIds
                .Select(seatId => new BookingSeat
                {
                    BookingId = createdBooking.Id,
                    SeatId = seatId
                })
                .ToList();

            await _bookingRepository
                .AddBookingSeatsAsync(bookingSeats);

            // 6. Return response
            return new BookingResponse
            {
                Id = createdBooking.Id,
                UserId = createdBooking.UserId,
                ShowId = createdBooking.ShowId,
                SeatIds = dto.SeatIds,
                BookingDate = createdBooking.BookingDate,
                TotalAmount = createdBooking.TotalAmount,
                Status = createdBooking.Status
            };
        }

      
        public async Task<List<BookingResponse>> GetAllAsync()
        {
            List<int> allseats = new List<int>();
            var bookings = await _bookingRepository.GetAllAsync();

            var t= bookings.Select(b => new BookingResponse
            {
                Id = b.Id,
                UserId = b.UserId,
                ShowId = b.ShowId,
                BookingDate = b.BookingDate,
                TotalAmount = b.TotalAmount,
                Status = b.Status
            }).ToList();
            
            foreach (var booking in t)
            {
                
                var allseatforid = await _bookingRepository.GetAllBookedSeatIdsAsync(booking.Id);
                foreach (var eachseat in allseatforid)
                {
                    booking.SeatIds.Add(eachseat);
                }
            }
            return t;
        }

        // Get Booking by Id
        public async Task<BookingResponse?> GetByIdAsync(int id)
        {
            var booking = await _bookingRepository
                .GetByIdAsync(id);

            if (booking == null)
                return null;

            return new BookingResponse
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ShowId = booking.ShowId,
                BookingDate = booking.BookingDate,
                TotalAmount = booking.TotalAmount,
                Status = booking.Status
            };
        }

        // Delete Booking
         public async Task<bool> CancelBookingAsync(
            int bookingId)
        {
            var booking =
                await _bookingRepository.GetByIdAsync(bookingId);

            // Booking doesn't exist
            if (booking == null)
            {
                return false;
            }


            // Already cancelled
            if (booking.Status == "Cancelled")
            {
                return false;
            }


            // Change status
            booking.Status = "Cancelled";


            // Save changes
            await _bookingRepository.UpdateAsync(booking);

            return true;
        }
    }
