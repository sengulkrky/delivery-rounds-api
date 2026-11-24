using DeliveryRoundsApi.Dtos;
using DeliveryRoundsApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryRoundsApi.Controllers;

[ApiController]
[Route("rounds")]
public class RoundsController : ControllerBase
{
    private readonly IRoundService _service;

    public RoundsController(IRoundService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rounds = await _service.GetAllAsync();
        return Ok(rounds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var round = await _service.GetByIdAsync(id);

        if (round is null)
        {
            return NotFound();
        }

        return Ok(round);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(RoundInputDto dto)
    {
        var round = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = round.Id }, round);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RoundInputDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("{id}/stops")]
    public async Task<IActionResult> GetStops(int id)
    {
        var stops = await _service.GetStopsAsync(id);

        if (stops is null)
        {
            return NotFound();
        }

        return Ok(stops);
    }

    [Authorize]
    [HttpPost("{id}/stops")]
    public async Task<IActionResult> AddStop(int id, StopInputDto dto)
    {
        if (!await _service.RoundExistsAsync(id))
        {
            return NotFound();
        }

        var createdBy = User.Identity?.Name
            ?? throw new InvalidOperationException("No username in token.");

        var stop = await _service.AddStopAsync(id, dto, createdBy);

        if (stop is null)
        {
            return Conflict();
        }

        return Created($"/rounds/{id}/stops/{stop.Id}", stop);
    }
}
