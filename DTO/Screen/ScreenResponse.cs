namespace MovieBooking.API.DTO.Screen;

    public class ScreenResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int TheaterId { get; set; }
    }
