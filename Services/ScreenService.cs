using MovieBooking.API.DTO.Screen;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<ScreenResponse> AddScreenAsync(CreateScreenRequest dto)
        {
            var screen = new Screen
            {
                Name = dto.Name,
                TheaterId = dto.TheaterId
            };

            var createdScreen = await _screenRepository.CreateAsync(screen);

            return new ScreenResponse
            {
                Id = createdScreen.Id,
                Name = createdScreen.Name,
                TheaterId = createdScreen.TheaterId
            };
        }

        public async Task<List<ScreenResponse>> GetScreensAsync()
        {
            var screens = await _screenRepository.GetAllAsync();

            return screens.Select(s => new ScreenResponse
            {
                Id = s.Id,
                Name = s.Name,
                TheaterId = s.TheaterId
            }).ToList();
        }

        public async Task<ScreenResponse?> GetScreenByIdAsync(int id)
        {
            var screen = await _screenRepository.GetByIdAsync(id);

            if (screen == null)
                return null;

            return new ScreenResponse
            {
                Id = screen.Id,
                Name = screen.Name,
                TheaterId = screen.TheaterId
            };
        }

        public async Task<bool> DeleteScreenAsync(int id)
        {
            return await _screenRepository.DeleteAsync(id);
        }
    }
