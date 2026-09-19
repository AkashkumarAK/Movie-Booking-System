using MovieBooking.API.DTO.Seats;
using MovieBooking.API.Models;
using MovieBooking.API.Repositories;

namespace MovieBooking.API.Services;

    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<SeatResponse> CreateAsync(CreateSeatRequest dto)
        {
            var seat = new Seat
            {
                ScreenId = dto.ScreenId,
                RowNumber = dto.RowNumber,
                SeatNumber = dto.SeatNumber,
                SeatType = dto.SeatType,
                Price = dto.Price
            };

            var createdSeat = await _seatRepository.CreateAsync(seat);

            return new SeatResponse
            {
                Id = createdSeat.Id,
                ScreenId = createdSeat.ScreenId,
                RowNumber = createdSeat.RowNumber,
                SeatNumber = createdSeat.SeatNumber,
                SeatType = createdSeat.SeatType,
                Price = createdSeat.Price
            };
        }

        public async Task<List<SeatResponse>> GetAllAsync()
        {
            var seats = await _seatRepository.GetAllAsync();

            return seats.Select(s => new SeatResponse
            {
                Id = s.Id,
                ScreenId = s.ScreenId,
                RowNumber = s.RowNumber,
                SeatNumber = s.SeatNumber,
                SeatType = s.SeatType,
                Price = s.Price
            }).ToList();
        }

        public async Task<SeatResponse?> GetByIdAsync(int id)
        {
            var seat = await _seatRepository.GetByIdAsync(id);

            if (seat == null)
                return null;

            return new SeatResponse
            {
                Id = seat.Id,
                ScreenId = seat.ScreenId,
                RowNumber = seat.RowNumber,
                SeatNumber = seat.SeatNumber,
                SeatType = seat.SeatType,
                Price = seat.Price
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _seatRepository.DeleteAsync(id);
        }
    }
