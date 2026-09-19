using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Booking;
using MovieBooking.API.Models;
using MovieBooking.API.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MovieBooking.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(
            IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        // POST: api/Booking
        [HttpPost]
        public async Task<IActionResult> CreateBooking(
            [FromBody] CreateBookingRequest request)
        {
             var userIdClaim = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = int.Parse(userIdClaim);

        var booking = await _bookingService.CreateAsync(
            userId,
            request);

        return Ok(booking);
        }


        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings =
                await _bookingService.GetAllAsync();

            return Ok(bookings);
        }


        // GET: api/Booking/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(
            int id)
        {
            var booking =
                await _bookingService.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound(
                    $"Booking with ID {id} not found.");
            }

            return Ok(booking);
        }


        // PUT: api/Booking/1/cancel
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelBooking(
            int id)
        {
            var result =
                await _bookingService.CancelBookingAsync(id);

            if (!result)
            {
                return BadRequest(
                    "Booking does not exist or is already cancelled.");
            }

            return Ok(
                $"Booking with ID {id} cancelled successfully.");
        }
    }
}