using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Data;

public interface IRoundRepository
{
    Task<List<Round>> GetAllAsync();
    Task<Round?> GetByIdAsync(int id);
    Task AddAsync(Round round);
    Task UpdateAsync(Round round);
    Task DeleteAsync(Round round);
    Task<bool> ExistsAsync(int id);

    Task<List<Stop>> GetStopsAsync(int roundId);
    Task<Stop?> GetStopByIdAsync(int id);
    Task AddStopAsync(Stop stop);
    Task DeleteStopAsync(Stop stop);
}
