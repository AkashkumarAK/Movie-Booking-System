namespace MovieBooking.API.DTO.Screen;

    public class CreateScreenRequest
    {
        public string Name { get; set; } = null!;

        public int TheaterId { get; set; }
    }
