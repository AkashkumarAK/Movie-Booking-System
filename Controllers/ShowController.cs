using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Show;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        // POST: api/Show
        [HttpPost]
        public async Task<IActionResult> CreateShow(CreateShowRequest dto)
        {
            var show = await _showService.CreateAsync(dto);

            return Ok(show);
        }

        // GET: api/Show
        [HttpGet]
        public async Task<IActionResult> GetAllShows()
        {
            var shows = await _showService.GetAllAsync();

            return Ok(shows);
        }

        // GET: api/Show/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            var show = await _showService.GetByIdAsync(id);

            if (show == null)
                return NotFound("Show not found");

            return Ok(show);
        }

        // DELETE: api/Show/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var deleted = await _showService.DeleteAsync(id);

            if (!deleted)
                return NotFound("Show not found");

            return Ok("Show deleted successfully");
        }
    }
