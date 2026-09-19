using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using MovieBooking.API.Data;
using MovieBooking.API.DTO.Auth;
using MovieBooking.API.Models;

namespace MovieBooking.API.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher;

    public AuthService(
        ApplicationDbContext context,
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

        _passwordHasher = new PasswordHasher<User>();
    }

    // REGISTER
    public async Task<string?> RegisterAsync(RegisterRequest request)
    {
        // Check whether email already exists
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (existingUser != null)
        {
            return null;
        }

        // Create user
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };

        // Hash password
        user.Password = _passwordHasher.HashPassword(
            user,
            request.Password);

        // Save user
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return GenerateJwtToken(user);
    }


    // LOGIN
    public async Task<string?> LoginAsync(LoginRequest request)
    {
        // 1. Find user by email
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return null;
        }

        // 2. Verify password
        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        // 3. Generate JWT
        return GenerateJwtToken(user);
    }


    // GENERATE JWT
    private string GenerateJwtToken(User user)
    {
        // Get JWT settings
        var key = _configuration["Jwt:Key"]!;
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        // Claims
        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()),

            new Claim(
                ClaimTypes.Name,
                user.Name),

            new Claim(
                ClaimTypes.Email,
                user.Email)
        };

        // Security key
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        // Credentials
        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        // Token
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(
                    _configuration["Jwt:ExpiryMinutes"]!)),
            signingCredentials: credentials
        );

        // Convert JWT to string
        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}