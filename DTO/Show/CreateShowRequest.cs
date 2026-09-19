namespace MovieBooking.API.DTO.Show;

    public class CreateShowRequest
    {
        public int MovieId { get; set; }

        public int ScreenId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
