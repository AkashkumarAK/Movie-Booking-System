using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);

        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _context.Movies
            .ToListAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _context.Movies.Remove(movie);

        await _context.SaveChangesAsync();
    }
}