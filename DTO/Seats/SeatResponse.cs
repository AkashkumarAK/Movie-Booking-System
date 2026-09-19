namespace MovieBooking.API.DTO.Seats;

    public class SeatResponse
    {
        public int Id { get; set; }

        public int ScreenId { get; set; }

        public string RowNumber { get; set; } = string.Empty;

        public int SeatNumber { get; set; }

        public string SeatType { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
