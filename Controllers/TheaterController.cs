using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Theater;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterService _theaterService;

        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTheaterRequest request)
        {
            var theater =
                await _theaterService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = theater.Id },
                theater);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theater =
                await _theaterService.GetByIdAsync(id);

            if (theater == null)
            {
                return NotFound();
            }

            return Ok(theater);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var theaters =
                await _theaterService.GetAllAsync();

            return Ok(theaters);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTheaterRequest request)
        {
            var updated =
                await _theaterService.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _theaterService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
