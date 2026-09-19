using MovieBooking.API.DTO.Theater;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public async Task<TheaterResponse> CreateAsync(
            CreateTheaterRequest request)
        {
            var theater = new Theater
            {
                Name = request.Name,
                Location = request.Location
            };

            var createdTheater =
                await _theaterRepository.CreateAsync(theater);

            return new TheaterResponse
            {
                Id = createdTheater.Id,
                Name = createdTheater.Name,
                Location = createdTheater.Location
            };
        }

        public async Task<TheaterResponse?> GetByIdAsync(int id)
        {
            var theater =
                await _theaterRepository.GetByIdAsync(id);

            if (theater == null)
            {
                return null;
            }

            return new TheaterResponse
            {
                Id = theater.Id,
                Name = theater.Name,
                Location = theater.Location
            };
        }

        public async Task<List<TheaterResponse>> GetAllAsync()
        {
            var theaters =
                await _theaterRepository.GetAllAsync();

            return theaters.Select(t => new TheaterResponse
            {
                Id = t.Id,
                Name = t.Name,
                Location = t.Location
            }).ToList();
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateTheaterRequest request)
        {
            var theater =
                await _theaterRepository.GetByIdAsync(id);

            if (theater == null)
            {
                return false;
            }

            theater.Name = request.Name;
            theater.Location = request.Location;

            return await _theaterRepository.UpdateAsync(theater);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _theaterRepository.DeleteAsync(id);
        }
    }
