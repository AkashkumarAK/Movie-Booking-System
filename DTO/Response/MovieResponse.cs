
namespace MovieBooking.API.DTO.Response;

public class MovieResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public string Language { get; set; } = string.Empty;
}