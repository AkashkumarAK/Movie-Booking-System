using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Screen;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        // POST: api/Screen
        [HttpPost]
        public async Task<IActionResult> AddScreen(CreateScreenRequest dto)
        {
            var screen = await _screenService.AddScreenAsync(dto);

            return Ok(screen);
        }

        // GET: api/Screen
        [HttpGet]
        public async Task<IActionResult> GetScreens()
        {
            var screens = await _screenService.GetScreensAsync();

            return Ok(screens);
        }

        // GET: api/Screen/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreenById(int id)
        {
            var screen = await _screenService.GetScreenByIdAsync(id);

            if (screen == null)
                return NotFound("Screen not found");

            return Ok(screen);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id)
        {
            var deleted = await _screenService.DeleteScreenAsync(id);

            if (!deleted)
                return NotFound("Screen not found");

            return Ok("Screen deleted successfully");
        }
    }
