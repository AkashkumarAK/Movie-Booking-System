namespace MovieBooking.API.DTO.Show;

    public class ShowResponse
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int ScreenId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
