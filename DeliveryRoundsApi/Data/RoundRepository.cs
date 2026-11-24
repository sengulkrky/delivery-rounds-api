using DeliveryRoundsApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DeliveryRoundsApi.Data;

public class RoundRepository : IRoundRepository
{
    private readonly AppDbContext _context;

    public RoundRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Round>> GetAllAsync()
    {
        return await _context.Rounds.ToListAsync();
    }

    public async Task<Round?> GetByIdAsync(int id)
    {
        return await _context.Rounds.Include(r => r.Stops).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Rounds.AnyAsync(r => r.Id == id);
    }

    public async Task<List<Stop>> GetStopsAsync(int roundId)
    {
        return await _context.Stops.Where(s => s.RoundId == roundId).ToListAsync();
    }

    public async Task<Stop?> GetStopByIdAsync(int id)
    {
        return await _context.Stops.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Round round)
    {
        _context.Rounds.Add(round);
        await _context.SaveChangesAsync();
    }

    public async Task AddStopAsync(Stop stop)
    {
        _context.Stops.Add(stop);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Round round)
    {
        _context.Rounds.Update(round);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Round round)
    {
        _context.Rounds.Remove(round);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStopAsync(Stop stop)
    {
        _context.Stops.Remove(stop);
        await _context.SaveChangesAsync();
    }
}
