using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public class ScreenRepository : IScreenRepository
    {
        private readonly ApplicationDbContext _context;

        public ScreenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Screen> CreateAsync(Screen screen)
        {
            await _context.Screens.AddAsync(screen);
            await _context.SaveChangesAsync();

            return screen;
        }

        public async Task<Screen?> GetByIdAsync(int id)
        {
            return await _context.Screens
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Screen>> GetAllAsync()
        {
            return await _context.Screens.ToListAsync();
        }

        public async Task<List<Screen>> GetByTheaterIdAsync(int theaterId)
        {
            return await _context.Screens
                .Where(s => s.TheaterId == theaterId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Screen screen)
        {
            _context.Screens.Update(screen);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var screen = await _context.Screens
                .FirstOrDefaultAsync(s => s.Id == id);

            if (screen == null)
            {
                return false;
            }

            _context.Screens.Remove(screen);
            await _context.SaveChangesAsync();

            return true;
        }
    }
