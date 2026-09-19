using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Data;
using MovieBooking.API.Models;

namespace MovieBooking.API.Repositories;

    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Show> CreateAsync(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return show;
        }

        public async Task<List<Show>> GetAllAsync()
        {
            return await _context.Shows
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Show?> GetByIdAsync(int id)
        {
            return await _context.Shows
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var show = await _context.Shows.FindAsync(id);

            if (show == null)
                return false;

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();

            return true;
        }
    }
