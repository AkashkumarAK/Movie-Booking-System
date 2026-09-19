namespace MovieBooking.API.DTO.Screen;

    public class UpdateScreenRequest
    {
        public string Name { get; set; } = null!;

        public int TheaterId { get; set; }
    }