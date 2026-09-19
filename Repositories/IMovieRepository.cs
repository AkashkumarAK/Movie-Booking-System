using MovieBooking.API.Models;
using MovieBooking.API.DTO.Response;

namespace MovieBooking.API.Repositories;

public interface IMovieRepository
{
    Task<Movie> CreateAsync(Movie movie);

    Task<Movie?> GetByIdAsync(int id);

    Task<List<Movie>> GetAllAsync();

    Task UpdateAsync(Movie movie);

    Task DeleteAsync(Movie movie);
}