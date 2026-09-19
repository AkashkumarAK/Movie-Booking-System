using MovieBooking.API.DTO.Auth;

namespace MovieBooking.API.Services;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterRequest request);

    Task<string?> LoginAsync(LoginRequest request);
}