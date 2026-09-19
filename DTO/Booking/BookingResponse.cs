namespace MovieBooking.API.DTO.Booking;

    public class BookingResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ShowId { get; set; }

        public List<int> SeatIds { get; set; } = new();

        public DateTime BookingDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;
    }
