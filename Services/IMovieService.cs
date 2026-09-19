using MovieBooking.API.DTO.Requests;
using MovieBooking.API.DTO.Response;

namespace MovieBooking.API.Services;

public interface IMovieService
{
    Task<MovieResponse> CreateAsync(CreateMovieRequest request);

    Task<MovieResponse?> GetByIdAsync(int id);

    Task<List<MovieResponse>> GetAllAsync();

    Task<bool> UpdateAsync(int id, UpdateMovieRequest request);

    Task<bool> DeleteAsync(int id);
}