using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public class TheaterRepository : ITheaterRepository
    {
        private readonly ApplicationDbContext _context;

        public TheaterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Theater> CreateAsync(Theater theater)
        {
            await _context.Theaters.AddAsync(theater);
            await _context.SaveChangesAsync();

            return theater;
        }

        public async Task<Theater?> GetByIdAsync(int id)
        {
            return await _context.Theaters
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Theater>> GetAllAsync()
        {
            return await _context.Theaters.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Theater theater)
        {
            _context.Theaters.Update(theater);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var theater = await _context.Theaters
                .FirstOrDefaultAsync(t => t.Id == id);

            if (theater == null)
            {
                return false;
            }

            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();

            return true;
        }
    }
