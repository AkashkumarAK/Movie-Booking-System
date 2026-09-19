using MovieBooking.API.DTO.Requests;
using MovieBooking.API.DTO.Response;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieResponse> CreateAsync(CreateMovieRequest request)
    {
        var movie = new Movie
        {
            Title = request.Title,
            Genre = request.Genre,
            DurationMinutes = request.DurationMinutes,
            Language = request.Language
        };

        var createdMovie = await _movieRepository.CreateAsync(movie);

        return MapToResponse(createdMovie);
    }

    public async Task<MovieResponse?> GetByIdAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
        {
            return null;
        }

        return MapToResponse(movie);
    }

    public async Task<List<MovieResponse>> GetAllAsync()
    {
        var movies = await _movieRepository.GetAllAsync();

        return movies
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<bool> UpdateAsync(int id, UpdateMovieRequest request)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
        {
            return false;
        }

        movie.Title = request.Title;
        movie.Genre = request.Genre;
        movie.DurationMinutes = request.DurationMinutes;
        movie.Language = request.Language;

        await _movieRepository.UpdateAsync(movie);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
        {
            return false;
        }

        await _movieRepository.DeleteAsync(movie);

        return true;
    }

    private static MovieResponse MapToResponse(Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            DurationMinutes = movie.DurationMinutes,
            Language = movie.Language
        };
    }
}