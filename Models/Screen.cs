namespace MovieBooking.API.Models;

    public class Screen
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int TheaterId { get; set; }

        public Theater Theater { get; set; } = null!;
    }
