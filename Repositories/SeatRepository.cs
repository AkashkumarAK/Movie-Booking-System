using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public class SeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext _context;

        public SeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seat> CreateAsync(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();

            return seat;
        }

        public async Task<List<Seat>> GetAllAsync()
        {
            return await _context.Seats
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            return await _context.Seats
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var seat = await _context.Seats.FindAsync(id);

            if (seat == null)
                return false;

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();

            return true;
        }
    }
