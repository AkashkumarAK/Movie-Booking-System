namespace MovieBooking.API.Models;

    public class Show
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public int ScreenId { get; set; }
        public Screen Screen { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
