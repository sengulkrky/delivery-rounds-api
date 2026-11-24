using DeliveryRoundsApi.Dtos;

namespace DeliveryRoundsApi.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<TokenDto?> LoginAsync(LoginDto dto);
}
