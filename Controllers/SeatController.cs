using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Seats;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        // POST: api/Seat
        [HttpPost]
        public async Task<IActionResult> CreateSeat(CreateSeatRequest dto)
        {
            var seat = await _seatService.CreateAsync(dto);

            return Ok(seat);
        }

        // GET: api/Seat
        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            var seats = await _seatService.GetAllAsync();

            return Ok(seats);
        }

        // GET: api/Seat/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(int id)
        {
            var seat = await _seatService.GetByIdAsync(id);

            if (seat == null)
                return NotFound("Seat not found");

            return Ok(seat);
        }

        // DELETE: api/Seat/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var deleted = await _seatService.DeleteAsync(id);

            if (!deleted)
                return NotFound("Seat not found");

            return Ok("Seat deleted successfully");
        }
    }
