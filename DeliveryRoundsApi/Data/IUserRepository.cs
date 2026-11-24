using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Data;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}
