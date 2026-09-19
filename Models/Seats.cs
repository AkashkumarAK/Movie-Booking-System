namespace MovieBooking.API.Models;

public class Seat
{
    public int Id { get; set; }

    public int ScreenId { get; set; }

    public Screen Screen { get; set; } = null!;

    public string RowNumber { get; set; } = string.Empty;

    public int SeatNumber { get; set; }

    public string SeatType { get; set; } = string.Empty;

    public decimal Price { get; set; }
}