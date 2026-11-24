using DeliveryRoundsApi.Dtos;

namespace DeliveryRoundsApi.Services;

public interface IRoundService
{
    Task<List<RoundDto>> GetAllAsync();
    Task<RoundDetailDto?> GetByIdAsync(int id);
    Task<RoundDto> CreateAsync(RoundInputDto dto);
    Task<bool> UpdateAsync(int id, RoundInputDto dto);
    Task<bool> DeleteAsync(int id);

    Task<bool> RoundExistsAsync(int roundId);
    Task<List<StopDto>?> GetStopsAsync(int roundId);
    Task<StopDto?> AddStopAsync(int roundId, StopInputDto dto, string createdBy);
    Task<bool> DeleteStopAsync(int id);
}
