using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Requests;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieRequest request)
    {
        var movie = await _movieService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = movie.Id },
            movie);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieService.GetAllAsync();

        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateMovieRequest request)
    {
        var updated = await _movieService.UpdateAsync(id, request);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _movieService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
} 
