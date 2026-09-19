namespace MovieBooking.API.DTO.Requests;

public class UpdateMovieRequest
{
    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public string Language { get; set; } = string.Empty;
}