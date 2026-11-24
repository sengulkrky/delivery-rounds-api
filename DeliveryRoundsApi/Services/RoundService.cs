using DeliveryRoundsApi.Data;
using DeliveryRoundsApi.Dtos;

namespace DeliveryRoundsApi.Services;

public class RoundService : IRoundService
{
    private readonly IRoundRepository _repository;

    public RoundService(IRoundRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RoundDto>> GetAllAsync()
    {
        var rounds = await _repository.GetAllAsync();
        return rounds.Select(r => r.ToDto()).ToList();
    }

    public async Task<RoundDetailDto?> GetByIdAsync(int id)
    {
        var round = await _repository.GetByIdAsync(id);
        return round?.ToDetailDto();
    }

    public async Task<RoundDto> CreateAsync(RoundInputDto dto)
    {
        var round = dto.ToEntity();
        await _repository.AddAsync(round);
        return round.ToDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var round = await _repository.GetByIdAsync(id);

        if (round is null)
        {
            return false;
        }

        await _repository.DeleteAsync(round);
        return true;
    }

    public async Task<bool> UpdateAsync(int id, RoundInputDto dto)
    {
        var round = await _repository.GetByIdAsync(id);

        if (round is null)
        {
            return false;
        }

        round.Name = dto.Name;
        round.Date = (DateOnly)dto.Date;
        round.DriverName = dto.DriverName;
        round.MaxStops = dto.MaxStops;

        await _repository.UpdateAsync(round);
        return true;
    }

    public async Task<bool> RoundExistsAsync(int roundId)
    {
        return await _repository.ExistsAsync(roundId);
    }

    public async Task<List<StopDto>?> GetStopsAsync(int roundId)
    {
        if (!await _repository.ExistsAsync(roundId)) 
        {
            return null;
        }

        var stops = await _repository.GetStopsAsync(roundId);
        return stops.Select(s => s.ToDto()).ToList();
    }

    public async Task<StopDto?> AddStopAsync(int roundId, StopInputDto dto, string createdBy)
    {
        var round = await _repository.GetByIdAsync(roundId);

        if (round is null || round.Stops.Count >= round.MaxStops)
        {
            return null;
        }

        var stop = dto.ToEntity();
        stop.RoundId = roundId;
        stop.CreatedBy = createdBy;

        await _repository.AddStopAsync(stop);
        return stop.ToDto();
    }

    public async Task<bool> DeleteStopAsync(int id)
    {
        var stop = await _repository.GetStopByIdAsync(id);
        if (stop is null)
        {
            return false;
        }

        await _repository.DeleteStopAsync(stop);
        return true;
    }
}
