namespace MovieBooking.API.DTO.Booking;

    public class CreateBookingRequest
    {

        public int ShowId { get; set; }

        public List<int> SeatIds { get; set; } = new();
    }
