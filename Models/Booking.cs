namespace MovieBooking.API.Models;

    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ShowId { get; set; }
        public Show Show { get; set; } = null!;

        public DateTime BookingDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;
    }
