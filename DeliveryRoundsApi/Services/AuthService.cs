using DeliveryRoundsApi.Data;
using DeliveryRoundsApi.Dtos;
using DeliveryRoundsApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeliveryRoundsApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _config;
    private readonly PasswordHasher<User> _hasher = new();

    public AuthService(IUserRepository repository, IConfiguration config)
    {
        _repository = repository;
        _config = config;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        if (await _repository.GetByUsernameAsync(dto.Username) is not null)
        {
            return false;
        }

        var user = new User { Username = dto.Username };
        user.PasswordHash = _hasher.HashPassword(user, dto.Password);

        await _repository.AddAsync(user);
        return true;
    }

    public async Task<TokenDto?> LoginAsync(LoginDto dto)
    {
        var user = await _repository.GetByUsernameAsync(dto.Username);
        if (user is null)
        {
            return null;
        }

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        return new TokenDto { Token = GenerateToken(user) };
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]
                ?? throw new InvalidOperationException("Jwt:Key ontbreekt: stel hem in met dotnet user-secrets (zie README)")));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
