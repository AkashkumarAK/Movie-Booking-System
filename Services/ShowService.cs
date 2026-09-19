using MovieBooking.API.DTO.Show;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<ShowResponse> CreateAsync(CreateShowRequest dto)
        {
            var show = new Show
            {
                MovieId = dto.MovieId,
                ScreenId = dto.ScreenId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            var createdShow = await _showRepository.CreateAsync(show);

            return new ShowResponse
            {
                Id = createdShow.Id,
                MovieId = createdShow.MovieId,
                ScreenId = createdShow.ScreenId,
                StartTime = createdShow.StartTime,
                EndTime = createdShow.EndTime
            };
        }

        public async Task<List<ShowResponse>> GetAllAsync()
        {
            var shows = await _showRepository.GetAllAsync();

            return shows.Select(s => new ShowResponse
            {
                Id = s.Id,
                MovieId = s.MovieId,
                ScreenId = s.ScreenId,
                StartTime = s.StartTime,
                EndTime = s.EndTime
            }).ToList();
        }

        public async Task<ShowResponse?> GetByIdAsync(int id)
        {
            var show = await _showRepository.GetByIdAsync(id);

            if (show == null)
                return null;

            return new ShowResponse
            {
                Id = show.Id,
                MovieId = show.MovieId,
                ScreenId = show.ScreenId,
                StartTime = show.StartTime,
                EndTime = show.EndTime
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _showRepository.DeleteAsync(id);
        }
    }
