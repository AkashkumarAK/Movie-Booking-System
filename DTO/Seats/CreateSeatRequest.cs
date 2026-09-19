namespace MovieBooking.API.DTO.Seats;

    public class CreateSeatRequest
    {
        public int ScreenId { get; set; }

        public string RowNumber { get; set; } = string.Empty;

        public int SeatNumber { get; set; }

        public string SeatType { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
